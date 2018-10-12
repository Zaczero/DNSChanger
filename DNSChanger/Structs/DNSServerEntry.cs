using System;

namespace DNSChanger.Structs
{
    public struct DNSServerEntry
    {
        public string Name;
        public float Latency;
        public DNSEntry[] DnsEntries;

        public override string ToString()
        {
            if (Latency == 0f)
            {
                return $"{Name}";
            }
            else
            {
                return $"{Name} (~{Math.Round(Latency, 1)}ms)";
            }
        }
    }
}
