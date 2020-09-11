using DNSChanger.Structs;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using Sentry;

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

			var proc = CreateNetshProcess("int show interface", true);
			proc.Start();

			while (!proc.StandardOutput.EndOfStream)
			{
				var outputLine = proc.StandardOutput.ReadLine();

				if (string.IsNullOrEmpty(outputLine))
					continue;

				SentrySdk.AddBreadcrumb($"{nameof(GetInterfaces)}: {nameof(outputLine)}={outputLine}", nameof(NetshHelper));

				var match = Regex.Match(outputLine, @"^(?<Enabled>Enabled|Disabled)\s+(?<Connected>Connected|Disconnected)\s+(?<Type>\S+)\s+(?<Name>.+)$");
				if (!match.Success) continue;

				var @interface = new Interface
				{
					Enabled = match.Groups["Enabled"].Value == "Enabled",
					Connected = match.Groups["Connected"].Value == "Connected",
					Type = match.Groups["Type"].Value,
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

			var proc = CreateNetshProcess($"int {ip} show dns \"{@interface.Name}\"", true);
			proc.Start();

			var isInList = false;

			while (!proc.StandardOutput.EndOfStream)
			{
				var str = proc.StandardOutput.ReadLine();
				if (string.IsNullOrEmpty(str))
					continue;

				if (!isInList)
				{
					var match = Regex.Match(str, @"^\s*(Statically Configured DNS Servers:|DNS servers configured through DHCP:)\s+(?<Value>\S+)$");
					if (!match.Success)
						continue;

					isInList = true;

					if (match.Groups["Value"].Value == "None")
						continue;
					
					entries.Add(new DNSEntry
					{
						Value = match.Groups["Value"].Value,
					});
				}
				else
				{
					var match = Regex.Match(str, @"^\s*Register with which suffix:");
					if (match.Success)
						break;

					var match2 = Regex.Match(str, @"^\s*(?<Value>\S+)$");
					if (!match2.Success)
						continue;

					entries.Add(new DNSEntry
					{
						Value = match2.Groups["Value"].Value,
					});
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

		public static void ResetDnsEntries(Interface @interface, string ip)
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
