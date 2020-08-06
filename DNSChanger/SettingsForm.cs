using DNSChanger.DNSCryptSettings;
using DNSChanger.Interfaces;
using DNSChanger.Properties;
using System.Collections.Generic;
using System.Windows.Forms;
using DNSChanger.Enums;
using DNSChanger.Structs;

namespace DNSChanger
{
	public partial class SettingsForm : Form
	{
		private readonly Dictionary<IDNSCryptSetting, ComboBox> controls;

		public SettingsForm()
		{
			InitializeComponent();
			Text = GlobalVars.Name + " Settings";
			Icon = Resources.Icon;

			Utilities.ApplyThemeToForm(this);
			
			controls = new Dictionary<IDNSCryptSetting, ComboBox>
			{
				{new DNSCryptSetting_ipv4_servers(), ipv4_servers},
				{new DNSCryptSetting_ipv6_servers(), ipv6_servers},
				{new DNSCryptSetting_dnscrypt_servers(), dnscrypt_servers},
				{new DNSCryptSetting_doh_servers(), doh_servers},
				{new DNSCryptSetting_require_dnssec(), require_dnssec},
				{new DNSCryptSetting_require_nolog(), require_nolog},
				{new DNSCryptSetting_require_nofilter(), require_nofilter},
				{new DNSCryptSetting_fallback_resolvers(), fallback_resolvers},
				{new DNSCryptSetting_dnscrypt_ephemeral_keys(), dnscrypt_ephemeral_keys},
				{new DNSCryptSetting_tls_disable_session_tickets(), tls_disable_session_tickets},
				{new DNSCryptSetting_netprobe_timeout(), netprobe_timeout},
				{new DNSCryptSetting_netprobe_address(), netprobe_address},
				{new DNSCryptSetting_block_ipv6(), block_ipv6},
				{new DNSCryptSetting_reject_ttl(), reject_ttl},
			};

			UpdateControls();
		}

		public void UpdateControls()
		{
			installButton.Text = "Download and install";
			installButton.Enabled = true;

			serviceButton.Text = "Start service";
			serviceButton.Enabled = true;

			configButton.Enabled = true;
			runButton.Enabled = true;

			foreach (var pair in controls)
				pair.Value.Enabled = true;

			configRecommendedButton.Enabled = true;
			configPrivacyButton.Enabled = true;
			saveConfigButton.Enabled = true;
			loadConfigButton.Enabled = true;

			if (!DNSCryptHelper.IsInstalled())
			{
				// not installed
				serviceButton.Enabled = false;
				configButton.Enabled = false;
				runButton.Enabled = false;

				foreach (var pair in controls)
					pair.Value.Enabled = false;

				configRecommendedButton.Enabled = false;
				configPrivacyButton.Enabled = false;
				saveConfigButton.Enabled = false;
				loadConfigButton.Enabled = false;
			}
			else
			{
				// installed
				installButton.Text = "Uninstall";

				if (DNSCryptHelper.IsRunning())
				{
					// running
					installButton.Enabled = false;
					serviceButton.Text = "Stop service";
					configButton.Enabled = false;
					runButton.Enabled = false;

					foreach (var pair in controls)
						pair.Value.Enabled = false;

					configRecommendedButton.Enabled = false;
					configPrivacyButton.Enabled = false;
					saveConfigButton.Enabled = false;
					loadConfigButton.Enabled = false;
				}
				else
				{
					// not running
				}

				// load controls
				var config = DNSCryptHelper.LoadConfig();

				foreach (var pair in controls)
				{
					var currentSetting = pair.Key.GetCurrentSetting(config);
					var settings = pair.Key.GetSettings(config);

					pair.Value.Items.Clear();
					
					var selectedItem = (object) null;

					foreach (var item in settings)
					{
						pair.Value.Items.Add(item);

						if ((string) item.Value == currentSetting)
							selectedItem = item;
					}

					if (selectedItem != null)
						pair.Value.SelectedItem = selectedItem;
					else
						pair.Value.SelectedIndex = 0;
				}
			}
		}

		private async void installButton_Click(object sender, System.EventArgs e)
		{
			installButton.Enabled = false;

			if (DNSCryptHelper.IsInstalled())
				DNSCryptHelper.Uninstall(progressBar, statusLabel);
			else
				await DNSCryptHelper.Install(progressBar, statusLabel);

			UpdateControls();
		}

		private async void serviceButton_Click(object sender, System.EventArgs e)
		{
			serviceButton.Enabled = false;

			if (DNSCryptHelper.IsRunning())
				await DNSCryptHelper.StopService(progressBar, statusLabel);
			else
			{
				saveConfigButton_Click(saveConfigButton, null);
				await DNSCryptHelper.StartService(progressBar, statusLabel);
			}

			UpdateControls();
		}

		private async void configButton_Click(object sender, System.EventArgs e)
		{
			configButton.Enabled = false;

			await DNSCryptHelper.OpenConfig();

			configButton.Enabled = true;
		}

		private async void runButton_Click(object sender, System.EventArgs e)
		{
			runButton.Enabled = false;

			await DNSCryptHelper.DebugProcess(progressBar, statusLabel);

			runButton.Enabled = true;
		}

		private void configRecommendedButton_Click(object sender, System.EventArgs e)
		{
			foreach (var pair in controls)
			{
				var setting = (ComboBoxItem) pair.Value.SelectedItem;
				var targetSetting = pair.Key.GetSetting();

				if ((string) setting.Value != targetSetting)
				{
					foreach (var item in pair.Value.Items)
					{
						setting = (ComboBoxItem) item;

						if ((string) setting.Value == targetSetting)
						{
							pair.Value.SelectedItem = item;
							break;
						}
					}
				}
			}

			Utilities.ButtonSuccessAnimation(sender);
		}

		private void configPrivacyButton_Click(object sender, System.EventArgs e)
		{
			foreach (var pair in controls)
			{
				var setting = (ComboBoxItem) pair.Value.SelectedItem;
				var targetSetting = pair.Key.GetSetting(DNSCryptSettingPreference.Privacy);

				if ((string) setting.Value != targetSetting)
				{
					foreach (var item in pair.Value.Items)
					{
						setting = (ComboBoxItem) item;

						if ((string) setting.Value == targetSetting)
						{
							pair.Value.SelectedItem = item;
							break;
						}
					}
				}
			}

			Utilities.ButtonSuccessAnimation(sender);
		}

		private void saveConfigButton_Click(object sender, System.EventArgs e)
		{
			var config = DNSCryptHelper.LoadConfig();

			foreach (var pair in controls)
			{
				var setting = (ComboBoxItem) pair.Value.SelectedItem;
				config = pair.Key.SetSetting(config, (string) setting.Value);
			}

			DNSCryptHelper.SaveConfig(config);

			Utilities.ButtonSuccessAnimation(sender);
		}

		private void loadConfigButton_Click(object sender, System.EventArgs e)
		{
			UpdateControls();

			Utilities.ButtonSuccessAnimation(sender);
		}
	}
}
