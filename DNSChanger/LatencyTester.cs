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

                    for (var i = 0; i < pings; i++)
                    {
                        var ping = new Ping();
                        var pong = ping.Send(address, 5 * 1000);

                        if (pong != null && pong.Status == IPStatus.Success)
                        {
                            results[i] = (int) pong.RoundtripTime;
                        }
                        else
                        {
                            break;
                        }
                    }

                    // ping failed
                    if (results.Any(r => r == 0)) continue;

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
                catch
                { }

                LatencyUpdated?.Invoke(null, null);
            }
        }
    }
}
