using System;

namespace DNSChanger.Structs
{
	public class DNSServerEntry
	{
		public string Name;
		public float Latency = -1f;
		public DNSEntry[] DnsEntries;

		public override string ToString()
		{
			if (Latency == -1f)
			{
				return $"{Name}";
			}

			if (Latency <= 1f)
			{
				return $"{Name} ( <1 ms )";
			}

			if (Latency == float.MaxValue)
			{
				return $"{Name} ( Timeout )";
			}

			return $"{Name} ( {Math.Round(Latency, 1)} ms )";
		}
	}
}
