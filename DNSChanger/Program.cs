using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
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
				        FileName = Utilities.GetProcessPath(),
						Arguments = Process.GetCurrentProcess().GetCommandLine(),
				        UseShellExecute = true,
				        Verb = "runas",
			        },
		        };

		        proc.Start();
				return;
	        }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!DNSValidate.ProcessArgs(args))
            {
                Application.Run(new DNSChangeDetectedForm());
            }

            if (args.Contains("-validate"))
            {
                return;
            }

            Application.Run(new MainForm());
        }
    }
}
