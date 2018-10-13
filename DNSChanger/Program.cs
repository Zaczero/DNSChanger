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
