using DNSChanger.Properties;
using DNSChanger.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DNSChanger
{
	public partial class MainForm : Form
	{
		private bool _ignoreDnsComboChanges;

		public MainForm()
		{
			InitializeComponent();
			Text = GlobalVars.Name;
			Icon = Resources.Icon;

			Utilities.ApplyThemeToForm(this);

			interfacesCombo.SelectedIndexChanged += InterfacesComboOnSelectedIndexChanged;
			dnsCombo.SelectedIndexChanged += DnsComboOnSelectedIndexChanged;
			v4primaryText.TextChanged += (sender, args) => MatchInputToDnsServer();
			v4secondaryText.TextChanged += (sender, args) => MatchInputToDnsServer();
			v6primaryText.TextChanged += (sender, args) => MatchInputToDnsServer();
			v6secondaryText.TextChanged += (sender, args) => MatchInputToDnsServer();
			LatencyTester.LatencyUpdated += (sender, args) => RefreshDnsLatency();
			
			FillDnsCombo();
			FillInterfacesCombo();
			ActiveControl = v4primaryText;

			new Task(() =>
			{
				LatencyTester.Run(GlobalVars.DNSServers, 5);
			}).Start();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Settings.Default.Save();
		}

		private Interface GetSelectedInterface()
		{
			return (Interface) ((ComboBoxItem) interfacesCombo.SelectedItem).Value;
		}

		private void FillInterfacesCombo()
		{
			interfacesCombo.Items.Clear();

			var interfaces = NetshHelper.GetInterfaces();
			var selectedItem = (object) null;
			for (var i = 0; i < interfaces.Count; i++)
			{
				var item = new ComboBoxItem(interfaces[i].ToString(), interfaces[i]);
				interfacesCombo.Items.Add(item);

				if (interfaces[i].ToString() == Settings.Default.SelectedInterface)
					selectedItem = item;
			}

			if (selectedItem != null)
				interfacesCombo.SelectedItem = selectedItem;
			else
				interfacesCombo.SelectedIndex = 0;
		}
		
		private void FillDnsCombo()
		{
			dnsCombo.Items.Clear();
			dnsCombo.Items.Add(new ComboBoxItem("Custom", null));

			foreach (var dnsServer in GlobalVars.DNSServers)
			{
				dnsCombo.Items.Add(new ComboBoxItem(dnsServer.ToString(), dnsServer));
			}

			dnsCombo.SelectedIndex = 0;
		}

		private void RefreshDnsLatency()
		{
			try
			{
				Invoke((MethodInvoker) delegate
				{
					_ignoreDnsComboChanges = true;

					for (var i = 0; i < dnsCombo.Items.Count; i++)
					{
						var item = (ComboBoxItem) dnsCombo.Items[i];
						if (item.Value == null) continue;

						var dnsServerEntryItem = (DNSServerEntry) item.Value;
						var dnsServerEntry = GlobalVars.DNSServers.First(d => d.Name == dnsServerEntryItem.Name);

						dnsCombo.Items[i] = new ComboBoxItem(dnsServerEntry.ToString(), dnsServerEntry);
					}

					_ignoreDnsComboChanges = false;
				});
			}
			catch
			{
				// ignored
			}
		}

		private void MatchInputToDnsServer()
		{
			_ignoreDnsComboChanges = true;

			var v4primary = v4primaryText.Text.Trim();
			var v4secondary = v4secondaryText.Text.Trim();
			var v6primary = v6primaryText.Text.Trim();
			var v6secondary = v6secondaryText.Text.Trim();

			dnsCombo.SelectedIndex = 0;

			for (var i = 0; i < dnsCombo.Items.Count; i++)
			{
				var success = true;

				var item = (ComboBoxItem) dnsCombo.Items[i];
				if (item.Value == null) continue;

				var dnsServer = (DNSServerEntry) item.Value;
				
				var dnsV4 = dnsServer.DnsEntries.Where(d => d.IsV4).ToList();
				var dnsV6 = dnsServer.DnsEntries.Where(d => d.IsV6).ToList();

				for (var j = 0; j < Math.Min(2, dnsV4.Count); j++)
				{
					if (v4primary != dnsV4[j].Value && v4secondary != dnsV4[j].Value)
					{
						// fail
						success = false;
						break;
					}
				}

				if (!success)
				{
					continue;
				}

				for (var j = 0; j < Math.Min(2, dnsV6.Count); j++)
				{
					if (v6primary != dnsV6[j].Value && v6secondary != dnsV6[j].Value)
					{
						// fail
						success = false;
						break;
					}
				}

				if (!success)
				{
					continue;
				}

				// success
				dnsCombo.SelectedIndex = i;
				break;
			}

			_ignoreDnsComboChanges = false;
		}


		private void InterfacesComboOnSelectedIndexChanged(object sender, EventArgs e)
		{
			v4primaryText.Text = null;
			v4secondaryText.Text = null;
			v6primaryText.Text = null;
			v6secondaryText.Text = null;
			
			var @interface = GetSelectedInterface();
			Settings.Default.SelectedInterface = @interface.ToString();
			
			var dnsEntries = NetshHelper.GetDnsEntries(@interface);
			var dnsV4 = dnsEntries.Where(d => d.IsV4).ToList();
			var dnsV6 = dnsEntries.Where(d => d.IsV6).ToList();

			for (var i = 0; i < 2; i++)
			{
				switch (i)
				{
					case 0:
						v4primaryText.Text = i < dnsV4.Count ? dnsV4[i].Value : string.Empty;
						break;
					case 1:
						v4secondaryText.Text = i < dnsV4.Count ? dnsV4[i].Value : string.Empty;
						break;
				}
			}

			for (var i = 0; i < 2; i++)
			{
				switch (i)
				{
					case 0:
						v6primaryText.Text = i < dnsV6.Count ? dnsV6[i].Value : string.Empty;
						break;
					case 1:
						v6secondaryText.Text = i < dnsV6.Count ? dnsV6[i].Value : string.Empty;
						break;
				}
			}
			
			MatchInputToDnsServer();
		}

		private void DnsComboOnSelectedIndexChanged(object sender, EventArgs e)
		{
			if (_ignoreDnsComboChanges) return;

			var item = (ComboBoxItem) dnsCombo.SelectedItem;
			if (item.Value == null) return;
			
			var dnsServer = (DNSServerEntry) item.Value;
			var dnsEntries = dnsServer.DnsEntries;

			var dnsV4 = dnsEntries.Where(d => d.IsV4).ToList();
			var dnsV6 = dnsEntries.Where(d => d.IsV6).ToList();

			for (var i = 0; i < 2; i++)
			{
				switch (i)
				{
					case 0:
						v4primaryText.Text = i < dnsV4.Count ? dnsV4[i].Value : string.Empty;
						break;
					case 1:
						v4secondaryText.Text = i < dnsV4.Count ? dnsV4[i].Value : string.Empty;
						break;
				}
			}

			for (var i = 0; i < 2; i++)
			{
				switch (i)
				{
					case 0:
						v6primaryText.Text = i < dnsV6.Count ? dnsV6[i].Value : string.Empty;
						break;
					case 1:
						v6secondaryText.Text = i < dnsV6.Count ? dnsV6[i].Value : string.Empty;
						break;
				}
			}
		}

		private void saveBtn_Click(object sender, EventArgs e)
		{
			var dnsEntries = new List<DNSEntry>(4);
			
			var v4primary = this.v4primaryText.Text.Trim();
			var v4secondary = this.v4secondaryText.Text.Trim();
			var v6primary = this.v6primaryText.Text.Trim();
			var v6secondary = this.v6secondaryText.Text.Trim();

			var ipv4regex = new Regex(@"^(\d+?[\.]?){4}$");
			var ipv6regex = new Regex(@"^([0-9a-fA-F]{0,4}:){1,7}[0-9a-fA-F]{0,4}$");

			if (!string.IsNullOrEmpty(v4primary) && ipv4regex.IsMatch(v4primary))
			{
				dnsEntries.Add(new DNSEntry(v4primary));
			}

			if (!string.IsNullOrEmpty(v4secondary) && ipv4regex.IsMatch(v4secondary))
			{
				dnsEntries.Add(new DNSEntry(v4secondary));
			}

			if (!string.IsNullOrEmpty(v6primary) && ipv6regex.IsMatch(v6primary))
			{
				dnsEntries.Add(new DNSEntry(v6primary));
			}

			if (!string.IsNullOrEmpty(v6secondary) && ipv6regex.IsMatch(v6secondary))
			{
				dnsEntries.Add(new DNSEntry(v6secondary));
			}
			
			var @interface = GetSelectedInterface();
			NetshHelper.UpdateDnsEntries(@interface, dnsEntries);
			NetshHelper.FlushDns();
			
			Utilities.ButtonSuccessAnimation(sender);
		}

		private void cancelBtn_Click(object sender, EventArgs e)
		{
			InterfacesComboOnSelectedIndexChanged(interfacesCombo, null);
			
			Utilities.ButtonSuccessAnimation(sender);
		}

		private void resetBtn_Click(object sender, EventArgs e)
		{
			var @interface = GetSelectedInterface();
			NetshHelper.ResetDnsEntries(@interface);
			NetshHelper.FlushDns();

			InterfacesComboOnSelectedIndexChanged(interfacesCombo, null);

			Utilities.ButtonSuccessAnimation(sender);
		}

		private void settingsLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var preIsInstalled = DNSCryptHelper.IsInstalled();
			var preIsRunning = preIsInstalled && DNSCryptHelper.IsRunning();

			new SettingsForm().ShowDialog(this);

			// check installation
			var shouldRestart = preIsInstalled != DNSCryptHelper.IsInstalled();

			// check service
			if (!shouldRestart && preIsInstalled && preIsRunning != DNSCryptHelper.IsRunning())
				shouldRestart = true;

			if (shouldRestart)
			{
				MessageBox.Show(
					$"DNSCrypt configuration change has been detected. " +
						$"{GlobalVars.Name} will now be restarted. " +
						$"Please remember to update your DNS server configuration.", 
					GlobalVars.Name, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

				Utilities.Restart();
			}
		}
	}
}