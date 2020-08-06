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
			if (!Utilities.IsAdministrator())
				Utilities.Restart();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			// backwards compatibility
			if (args.Contains("-validate"))
				return;

			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

			if (DNSCryptHelper.IsInstalled() && DNSCryptHelper.IsRunning())
				GlobalVars.DNSServers.Insert(0, DNSCryptHelper.GetDNSServer());

			Application.Run(new MainForm());
		}
	}
}
