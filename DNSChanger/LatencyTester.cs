using DNSChanger.Structs;
using Sentry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace DNSChanger
{
	public static class LatencyTester
	{
		public static event EventHandler LatencyUpdated;

		public static void Run(IEnumerable<DNSServerEntry> dnsServers, int pings)
		{
			SentrySdk.AddBreadcrumb($"{nameof(Run)}: {nameof(pings)}={pings}", nameof(LatencyTester));

			foreach (var dnsServer in dnsServers)
			{
				try
				{
					var results = new int[pings];
					var address = dnsServer.DnsEntries.First().Value;
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

						dnsServer.Latency = (float) totalMs / pings;
					}
					else
					{
						dnsServer.Latency = float.NaN;
					}
				}
				catch (Exception ex)
				{
					SentrySdk.CaptureException(ex);
				}

				LatencyUpdated?.Invoke(null, null);
			}

			SentrySdk.AddBreadcrumb($"{nameof(Run)}: Completed", nameof(LatencyTester));
		}
	}
}
