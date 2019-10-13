using DNSChanger.Structs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace DNSChanger
{
    public partial class DNSChangeDetectedForm : Form
    {
        public DNSChangeDetectedForm()
        {
            InitializeComponent();
            Text = GlobalVars.Name + @" DNS Change Detected";
            Icon = Properties.Resources.Icon;


            var @interface = DNSValidate.GetInterfaceToValidate().Value;
            interfaceTb.Text = @interface.Name;
            savedTb.Text = DNSValidate.GetDnsEntriesToValidate();
            systemTb.Text = NetshHelper.GetDnsEntries(@interface).Select(e => e.Value).Aggregate((r, v) => r += ";" + v);
        }

        private void quickBtn_Click(object sender, EventArgs e)
        {
            var @interface = DNSValidate.GetInterfaceToValidate().Value;
            
            var saved = DNSValidate.GetDnsEntriesToValidate().Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
            var dnsEntries = new List<DNSEntry>(saved.Length);
            dnsEntries.AddRange(saved.Select(s => new DNSEntry(s)));

            NetshHelper.UpdateDnsEntries(@interface, dnsEntries);
            NetshHelper.FlushDns();

            MessageBox.Show(@"DNS settings applied!", GlobalVars.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void manualBtn_Click(object sender, EventArgs e)
        {
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = Utilities.GetProcessPath(),
                    UseShellExecute = true,
                    Verb = "runas",
                },
            };

            proc.Start();
            Close();
        }

        private void ignoreBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
