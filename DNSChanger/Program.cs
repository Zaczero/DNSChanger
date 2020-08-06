using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace DNSChanger
{
	public static class Program
	{
		[STAThread]
		public static void Main(string[] args)
		{
			if (!Utilities.IsAdministrator())
			{
				var proc = new Process
				{
					StartInfo = new ProcessStartInfo
					{
						FileName = Utilities.GetCurrentProcessPath(),
						Arguments = Process.GetCurrentProcess().GetCommandLine(),
						UseShellExecute = true,
						Verb = "runas",
					},
				};

				try
				{
					proc.Start();
				}
				catch
				{
					// ignored
				}

				return;
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			if (args.Contains("-validate"))
				return;

			Application.Run(new MainForm());
		}
	}
}
