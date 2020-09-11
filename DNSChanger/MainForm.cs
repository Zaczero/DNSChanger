using DNSChanger.Properties;
using DNSChanger.Structs;
using Sentry;
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
			SentrySdk.AddBreadcrumb($"{nameof(MainForm)}", nameof(MainForm));

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
			SentrySdk.AddBreadcrumb($"{nameof(MainForm_FormClosing)}", nameof(MainForm));
			Settings.Default.Save();
		}

		private Interface GetSelectedInterface()
		{
			return (Interface) ((ComboBoxItem) interfacesCombo.SelectedItem).Value;
		}

		private void FillInterfacesCombo()
		{
			SentrySdk.AddBreadcrumb($"{nameof(FillInterfacesCombo)}", nameof(MainForm));

			interfacesCombo.Items.Clear();

			var selectedItem = (object) null;

			foreach (var @interface in NetshHelper.GetInterfaces())
			{
				var item = new ComboBoxItem(@interface.ToString(), @interface);
				interfacesCombo.Items.Add(item);

				if (@interface.ToString() == Settings.Default.SelectedInterface)
					selectedItem = item;
			}

			// some users do not have any interfaces available
			if (interfacesCombo.Items.Count <= 0)
			{
				const string message = "Failed to fetch network interface list";

				MessageBox.Show(message, GlobalVars.Name + " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				throw new Exception(message);
			}

			if (selectedItem != null)
				interfacesCombo.SelectedItem = selectedItem;
			else
				interfacesCombo.SelectedIndex = 0;
		}
		
		private void FillDnsCombo()
		{
			SentrySdk.AddBreadcrumb($"{nameof(FillDnsCombo)}", nameof(MainForm));

			dnsCombo.Items.Clear();
			dnsCombo.Items.Add(new ComboBoxItem("Custom", null));

			foreach (var dnsServer in GlobalVars.DNSServers)
				dnsCombo.Items.Add(new ComboBoxItem(dnsServer.ToString(), dnsServer));

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

			var v4Primary = v4primaryText.Text.Trim();
			var v4Secondary = v4secondaryText.Text.Trim();
			var v6Primary = v6primaryText.Text.Trim();
			var v6Secondary = v6secondaryText.Text.Trim();

			dnsCombo.SelectedIndex = 0;

			for (var i = 0; i < dnsCombo.Items.Count; i++)
			{
				var success = true;

				var item = (ComboBoxItem) dnsCombo.Items[i];
				if (item.Value == null)
					continue;

				var dnsServer = (DNSServerEntry) item.Value;
				
				var dnsV4 = dnsServer.DnsEntries.Where(d => d.IsV4).ToList();
				var dnsV6 = dnsServer.DnsEntries.Where(d => d.IsV6).ToList();

				for (var j = 0; j < Math.Min(2, dnsV4.Count); j++)
				{
					if (v4Primary != dnsV4[j].Value && v4Secondary != dnsV4[j].Value)
					{
						// fail
						success = false;
						break;
					}
				}

				if (!success)
					continue;

				for (var j = 0; j < Math.Min(2, dnsV6.Count); j++)
				{
					if (v6Primary != dnsV6[j].Value && v6Secondary != dnsV6[j].Value)
					{
						// fail
						success = false;
						break;
					}
				}

				if (!success)
					continue;
					
				SentrySdk.AddBreadcrumb($"{nameof(MatchInputToDnsServer)}: success={dnsServer.Name}", nameof(MainForm));

				// success
				dnsCombo.SelectedIndex = i;
				break;
			}

			_ignoreDnsComboChanges = false;
		}


		private void InterfacesComboOnSelectedIndexChanged(object sender, EventArgs e)
		{
			SentrySdk.AddBreadcrumb($"{nameof(InterfacesComboOnSelectedIndexChanged)}", nameof(MainForm));

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
			if (_ignoreDnsComboChanges)
				return;

			var item = (ComboBoxItem) dnsCombo.SelectedItem;
			if (item.Value == null)
				return;

			SentrySdk.AddBreadcrumb($"{nameof(DnsComboOnSelectedIndexChanged)}", nameof(MainForm));
			
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
			SentrySdk.AddBreadcrumb($"{nameof(saveBtn_Click)}", nameof(MainForm));

			var dnsEntries = new List<DNSEntry>(4);
			
			var v4Primary = v4primaryText.Text.Trim();
			var v4Secondary = v4secondaryText.Text.Trim();
			var v6Primary = v6primaryText.Text.Trim();
			var v6Secondary = v6secondaryText.Text.Trim();

			var ipv4Regex = new Regex(@"^(\d+?[\.]?){4}$");
			var ipv6Regex = new Regex(@"^([0-9a-fA-F]{0,4}:){1,7}[0-9a-fA-F]{0,4}$");

			if (!string.IsNullOrEmpty(v4Primary) && ipv4Regex.IsMatch(v4Primary))
				dnsEntries.Add(new DNSEntry(v4Primary));

			if (!string.IsNullOrEmpty(v4Secondary) && ipv4Regex.IsMatch(v4Secondary))
				dnsEntries.Add(new DNSEntry(v4Secondary));

			if (!string.IsNullOrEmpty(v6Primary) && ipv6Regex.IsMatch(v6Primary))
				dnsEntries.Add(new DNSEntry(v6Primary));

			if (!string.IsNullOrEmpty(v6Secondary) && ipv6Regex.IsMatch(v6Secondary))
				dnsEntries.Add(new DNSEntry(v6Secondary));
			
			var @interface = GetSelectedInterface();
			NetshHelper.UpdateDnsEntries(@interface, dnsEntries);
			NetshHelper.FlushDns();
			
			Utilities.ButtonSuccessAnimation(sender);
		}

		private void cancelBtn_Click(object sender, EventArgs e)
		{
			SentrySdk.AddBreadcrumb($"{nameof(cancelBtn_Click)}", nameof(MainForm));

			InterfacesComboOnSelectedIndexChanged(interfacesCombo, null);
			
			Utilities.ButtonSuccessAnimation(sender);
		}

		private void resetBtn_Click(object sender, EventArgs e)
		{
			SentrySdk.AddBreadcrumb($"{nameof(resetBtn_Click)}", nameof(MainForm));

			var @interface = GetSelectedInterface();
			NetshHelper.ResetDnsEntries(@interface);
			NetshHelper.FlushDns();

			InterfacesComboOnSelectedIndexChanged(interfacesCombo, null);

			Utilities.ButtonSuccessAnimation(sender);
		}

		private void settingsLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			SentrySdk.AddBreadcrumb($"{nameof(settingsLabel_LinkClicked)}", nameof(MainForm));

			var preIsInstalled = DNSCryptHelper.IsInstalled();
			var preIsRunning = preIsInstalled && DNSCryptHelper.IsRunning();

			SentrySdk.AddBreadcrumb($"{nameof(settingsLabel_LinkClicked)}: {nameof(preIsInstalled)}={preIsInstalled}, {nameof(preIsRunning)}={preIsRunning}", nameof(MainForm));

			new SettingsForm().ShowDialog(this);

			// check installation
			var shouldRestart = preIsInstalled != DNSCryptHelper.IsInstalled();

			// check service
			if (!shouldRestart && preIsInstalled && preIsRunning != DNSCryptHelper.IsRunning())
				shouldRestart = true;
				
			SentrySdk.AddBreadcrumb($"{nameof(settingsLabel_LinkClicked)}: {nameof(shouldRestart)}={shouldRestart}", nameof(MainForm));

			if (shouldRestart)
				Utilities.Restart();
		}
	}
}