using DNSChanger.Structs;
using System;
using System.Linq;
using System.Net.NetworkInformation;

namespace DNSChanger
{
    public static class LatencyTester
    {
        public static event EventHandler LatencyUpdated;

        public static void Run(DNSServerEntry[] dnsServers, int pings)
        {
            for (var j = 0; j < dnsServers.Length; j++)
            {
                try
                {
                    var results = new int[pings];
                    var address = dnsServers[j].DnsEntries.First().Value;
                    var success = true;

                    for (var i = 0; i < pings; i++)
                    {
                        var ping = new Ping();
                        var pong = ping.Send(address, 1000);

                        if (pong != null && pong.Status == IPStatus.Success)
                        {
                            results[i] = (int) pong.RoundtripTime;
                        }
                        else
                        {
	                        success = false;
                            break;
                        }
                    }

                    if (success)
                    {
	                    var max = results.Max();
	                    var maxRemoved = false;
	                    var totalMs = 0;

	                    foreach (var result in results)
	                    {
		                    if (!maxRemoved && result == max)
		                    {
			                    maxRemoved = true;
			                    continue;
		                    }

		                    totalMs += result;
	                    }

	                    dnsServers[j].Latency = (float) totalMs / pings;
                    }
                    else
                    {
	                    dnsServers[j].Latency = float.MaxValue;
                    }
                }
                catch
                { }

                LatencyUpdated?.Invoke(null, null);
            }
        }
    }
}
