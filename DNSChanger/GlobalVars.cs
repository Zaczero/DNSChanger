using DNSChanger.Structs;

namespace DNSChanger
{
    public static class GlobalVars
    {
        public static string Name = "DNSChanger";
        public static string Author = "Zaczero";

        public static DNSServerEntry[] DnsServers = new []
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
