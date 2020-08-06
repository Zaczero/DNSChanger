using Sentry;
using System;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace DNSChanger
{
	public static class Program
	{
		[STAThread]
		public static void Main(string[] args)
		{
			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
			SentrySdk.Init("https://d18c4851a8074b0ebf7b95392f8a69c3@o321212.ingest.sentry.io/5380665");
			
			// backwards compatibility
			if (args.Contains("-validate"))
				return;

			if (!Utilities.IsAdministrator())
			{
				SentrySdk.AddBreadcrumb($"{nameof(Main)}: Application run with user privileges", nameof(Program));
				Utilities.Restart();
			}

			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

			if (DNSCryptHelper.IsInstalled() && DNSCryptHelper.IsRunning())
			{
				SentrySdk.AddBreadcrumb($"{nameof(Main)}: Add DNSCrypt to DNSServers list", nameof(Program));
				GlobalVars.DNSServers.Insert(0, DNSCryptHelper.GetDNSServer());
			}
			
			SentrySdk.AddBreadcrumb($"{nameof(Main)}: Application start", nameof(Program));
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
