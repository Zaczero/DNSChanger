using DNSChanger.Structs;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DNSChanger
{
	public static class GlobalVars
	{
		public const string Name = "DNSChanger";
		
		// source: https://www.regexpal.com/?fam=104038
		public const string IpAddressRegexPattern = "((^\\s*((([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5]))\\s*$)|(^\\s*((([0-9A-Fa-f]{1,4}:){7}([0-9A-Fa-f]{1,4}|:))|(([0-9A-Fa-f]{1,4}:){6}(:[0-9A-Fa-f]{1,4}|((25[0-5]|2[0-4]\\d|1\\d\\d|[1-9]?\\d)(\\.(25[0-5]|2[0-4]\\d|1\\d\\d|[1-9]?\\d)){3})|:))|(([0-9A-Fa-f]{1,4}:){5}(((:[0-9A-Fa-f]{1,4}){1,2})|:((25[0-5]|2[0-4]\\d|1\\d\\d|[1-9]?\\d)(\\.(25[0-5]|2[0-4]\\d|1\\d\\d|[1-9]?\\d)){3})|:))|(([0-9A-Fa-f]{1,4}:){4}(((:[0-9A-Fa-f]{1,4}){1,3})|((:[0-9A-Fa-f]{1,4})?:((25[0-5]|2[0-4]\\d|1\\d\\d|[1-9]?\\d)(\\.(25[0-5]|2[0-4]\\d|1\\d\\d|[1-9]?\\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){3}(((:[0-9A-Fa-f]{1,4}){1,4})|((:[0-9A-Fa-f]{1,4}){0,2}:((25[0-5]|2[0-4]\\d|1\\d\\d|[1-9]?\\d)(\\.(25[0-5]|2[0-4]\\d|1\\d\\d|[1-9]?\\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){2}(((:[0-9A-Fa-f]{1,4}){1,5})|((:[0-9A-Fa-f]{1,4}){0,3}:((25[0-5]|2[0-4]\\d|1\\d\\d|[1-9]?\\d)(\\.(25[0-5]|2[0-4]\\d|1\\d\\d|[1-9]?\\d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){1}(((:[0-9A-Fa-f]{1,4}){1,6})|((:[0-9A-Fa-f]{1,4}){0,4}:((25[0-5]|2[0-4]\\d|1\\d\\d|[1-9]?\\d)(\\.(25[0-5]|2[0-4]\\d|1\\d\\d|[1-9]?\\d)){3}))|:))|(:(((:[0-9A-Fa-f]{1,4}){1,7})|((:[0-9A-Fa-f]{1,4}){0,5}:((25[0-5]|2[0-4]\\d|1\\d\\d|[1-9]?\\d)(\\.(25[0-5]|2[0-4]\\d|1\\d\\d|[1-9]?\\d)){3}))|:)))(%.+)?\\s*$))";
		public static readonly Regex IpAddressRegex = new Regex(IpAddressRegexPattern);

		public static readonly List<DNSServerEntry> DNSServers = new List<DNSServerEntry>
		{
			new DNSServerEntry
			{
				Name = "Cloudflare",
				DnsEntries = new []
				{
					new DNSEntry("1.1.1.1"),
					new DNSEntry("1.0.0.1"),
					new DNSEntry("2606:4700:4700::1111"),
					new DNSEntry("2606:4700:4700::1001"), 
				},
			},

			new DNSServerEntry
			{
				Name = "Google",
				DnsEntries = new []
				{
					new DNSEntry("8.8.8.8"),
					new DNSEntry("8.8.4.4"),
					new DNSEntry("2001:4860:4860::8888"),
					new DNSEntry("2001:4860:4860::8844"), 
				},
			},

			new DNSServerEntry
			{
				Name = "AdGuard",
				DnsEntries = new []
				{
					new DNSEntry("94.140.14.14"),
					new DNSEntry("94.140.15.15"),
					new DNSEntry("2a10:50c0::ad1:ff"),
					new DNSEntry("2a10:50c0::ad2:ff"), 
				},
			},

			new DNSServerEntry
			{
				Name = "AdGuard - Family protection",
				DnsEntries = new []
				{
					new DNSEntry("94.140.14.15"),
					new DNSEntry("94.140.15.16"),
					new DNSEntry("2a10:50c0::bad1:ff"),
					new DNSEntry("2a10:50c0::bad2:ff"), 
				},
			},

			new DNSServerEntry
			{
				Name = "AdGuard - Non filtering",
				DnsEntries = new []
				{
					new DNSEntry("94.140.14.140"),
					new DNSEntry("94.140.14.141"),
					new DNSEntry("2a10:50c0::1:ff"),
					new DNSEntry("2a10:50c0::2:ff"), 
				},
			},

			new DNSServerEntry
			{
				Name = "CZ.NIC",
				DnsEntries = new []
				{
					new DNSEntry("193.17.47.1"),
					new DNSEntry("185.43.135.1"),
					new DNSEntry("2001:148f:ffff::1"),
					new DNSEntry("2001:148f:fffe::1"), 
				},
			},

			new DNSServerEntry
			{
				Name = "NextDNS",
				DnsEntries = new []
				{
					new DNSEntry("45.90.28.119"),
					new DNSEntry("45.90.30.119"),
					new DNSEntry("2a07:a8c0::4e:9d2a"),
					new DNSEntry("2a07:a8c1::4e:9d2a"), 
				},
			},

			new DNSServerEntry
			{
				Name = "OpenDNS",
				DnsEntries = new []
				{
					new DNSEntry("208.67.222.222"),
					new DNSEntry("208.67.220.220"),
					new DNSEntry("2620:0:ccc::2"),
					new DNSEntry("2620:0:ccd::2"), 
				},
			},

			new DNSServerEntry
			{
				Name = "Quad9",
				DnsEntries = new []
				{
					new DNSEntry("9.9.9.9"),
					new DNSEntry("149.112.112.112"),
					new DNSEntry("2620:fe::fe"),
					new DNSEntry("2620:fe::9"), 
				},
			},
		};
	}
}
