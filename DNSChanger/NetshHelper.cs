using DNSChanger.Structs;
using Sentry;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace DNSChanger
{
	public static class NetshHelper
	{
		private static Process CreateNetshProcess(string args, bool redirectOutput)
		{
			SentrySdk.AddBreadcrumb($"{nameof(CreateNetshProcess)}: {nameof(args)}={args}", nameof(NetshHelper));

			return new Process
			{
				StartInfo =
				{
					FileName = "netsh",
					Arguments = args,
					Verb = "runas",
					UseShellExecute = false,
					CreateNoWindow = true,
					RedirectStandardOutput = redirectOutput,
				}
			};
		}

		public static List<Interface> GetInterfaces()
		{
			var interfaces = new List<Interface>();
			var process = CreateNetshProcess("int show interface", true);

			process.Start();

			var isList = false;

			while (!process.StandardOutput.EndOfStream)
			{
				var str = process.StandardOutput.ReadLine();

				if (string.IsNullOrEmpty(str))
					continue;
					
				// added for purpose of debugging: https://github.com/Zaczero/DNSChanger/issues/2
				SentrySdk.AddBreadcrumb($"{nameof(GetInterfaces)}: {nameof(str)}={str}", nameof(NetshHelper));

				if (!isList)
				{
					if (str.Length > 0 && str.StartsWith(new string(str[0], 6), StringComparison.Ordinal))
						isList = true;

					continue;
				}

				var match = Regex.Match(str, @"^(?<AdminState>\S+)\s+(?<State>\S+)\s+(?<Type>\S+)\s+(?<Name>.+)$");
				if (!match.Success)
					continue;

				var @interface = new Interface
				{
					Name = match.Groups["Name"].Value,
				};

				interfaces.Add(@interface);
			}

			return interfaces;
		}

		public static List<DNSEntry> GetDnsEntries(Interface @interface)
		{
			var v4 = GetDnsEntries(@interface, "ipv4");
			var v6 = GetDnsEntries(@interface, "ipv6");

			v4.AddRange(v6);

			return v4;
		}

		private static List<DNSEntry> GetDnsEntries(Interface @interface, string ip)
		{
			var entries = new List<DNSEntry>();
			var process = CreateNetshProcess($"int {ip} show dns \"{@interface.Name}\"", true);

			process.Start();

			while (!process.StandardOutput.EndOfStream)
			{
				var str = process.StandardOutput.ReadLine();

				if (string.IsNullOrEmpty(str))
					continue;

				// added for purpose of debugging: https://github.com/Zaczero/DNSChanger/issues/2
				SentrySdk.AddBreadcrumb($"{nameof(GetDnsEntries)}: {nameof(str)}={str}", nameof(NetshHelper));

				var strSplit = str.Split(new [] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);

				foreach (var strPart in strSplit)
				{
					// better safe than sorry :-)
					var strPartTrimmed = strPart.Trim();

					var match = Regex.Match(strPartTrimmed, GlobalVars.IpAddressRegexPattern);
					if (match.Success)
					{
						entries.Add(new DNSEntry
						{
							Value = match.Value,
						});
					}
				}
			}

			return entries;
		}

		public static void UpdateDnsEntries(Interface @interface, List<DNSEntry> entries)
		{
			UpdateDnsEntries(@interface, entries.Where(e => e.IsV4).ToList(), "ipv4");
			UpdateDnsEntries(@interface, entries.Where(e => e.IsV6).ToList(), "ipv6");
		}

		private static void UpdateDnsEntries(Interface @interface, IReadOnlyList<DNSEntry> entries, string ip)
		{
			if (entries.Count == 0)
			{
				ResetDnsEntries(@interface, ip);
			}

			for (var i = 0; i < entries.Count; i++)
			{
				var entry = entries[i];

				// set
				if (i == 0)
				{
					var proc = CreateNetshProcess($"int {ip} set dns \"{@interface.Name}\" static {entry.Value} primary validate=no", false);
					proc.Start();
					proc.WaitForExit();
				}
				// add
				else
				{
					var proc = CreateNetshProcess($"int {ip} add dns \"{@interface.Name}\" {entry.Value} index={i + 1} validate=no", false);
					proc.Start();
					proc.WaitForExit();
				}
			}
		}
		
		public static void ResetDnsEntries(Interface @interface)
		{
			ResetDnsEntries(@interface, "ipv4");
			ResetDnsEntries(@interface, "ipv6");
		}

		private static void ResetDnsEntries(Interface @interface, string ip)
		{
			var proc = CreateNetshProcess($"int {ip} set dns \"{@interface.Name}\" dhcp", false);
			proc.Start();
			proc.WaitForExit();
		}

		public static void FlushDns()
		{
			SentrySdk.AddBreadcrumb($"{nameof(FlushDns)}", nameof(NetshHelper));

			var proc = new Process
			{
				StartInfo =
				{
					FileName = "ipconfig",
					Arguments = "/flushdns",
					Verb = "runas",
					UseShellExecute = false,
					CreateNoWindow = true,
				}
			};

			proc.Start();
			proc.WaitForExit();
		}
	}
}
