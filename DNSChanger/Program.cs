using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;

namespace DNSChanger
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            if (!IsAdministrator())
            {
                var proc = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = Process.GetCurrentProcess().MainModule.FileName,
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

        public static bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
