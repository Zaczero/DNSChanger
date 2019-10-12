using System;
using System.Linq;
using System.Windows.Forms;

namespace DNSChanger
{
	public static class Program
    {
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
