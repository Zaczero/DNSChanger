using DNSChanger.Structs;

namespace DNSChanger
{
	public static class GlobalVars
	{
		public const string Name = "DNSChanger";

		public static readonly DNSServerEntry[] DnsServers =
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
					new DNSEntry("176.103.130.130"),
					new DNSEntry("176.103.130.131"),
					new DNSEntry("2a00:5a60::ad1:0ff"),
					new DNSEntry("2a00:5a60::ad2:0ff"), 
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
					new DNSEntry("45.90.28.205"),
					new DNSEntry("45.90.30.205"),
					new DNSEntry("2a07:a8c0::1f:5db8"),
					new DNSEntry("2a07:a8c1::1f:5db8"), 
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
		};
	}
}
