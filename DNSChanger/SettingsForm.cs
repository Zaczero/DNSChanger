using DNSChanger.DNSCryptSettings;
using DNSChanger.Enums;
using DNSChanger.Interfaces;
using DNSChanger.Properties;
using DNSChanger.Structs;
using Sentry;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DNSChanger
{
	public partial class SettingsForm : Form
	{
		private readonly Dictionary<IDNSCryptSetting, ComboBox> _controls;

		public SettingsForm()
		{
			SentrySdk.AddBreadcrumb($"{nameof(SettingsForm)}", nameof(SettingsForm));

			InitializeComponent();
			Text = GlobalVars.Name + " Settings";
			Icon = Resources.Icon;

			Utilities.ApplyThemeToForm(this);
			
			_controls = new Dictionary<IDNSCryptSetting, ComboBox>
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
			SentrySdk.AddBreadcrumb($"{nameof(UpdateControls)}", nameof(SettingsForm));

			installButton.Text = "Download and install";
			installButton.Enabled = true;

			serviceButton.Text = "Start service";
			serviceButton.Enabled = true;

			configButton.Enabled = true;
			debugButton.Enabled = true;

			foreach (var pair in _controls)
				pair.Value.Enabled = true;

			configRecommendedButton.Enabled = true;
			configPrivacyButton.Enabled = true;
			saveConfigButton.Enabled = true;
			loadConfigButton.Enabled = true;

			if (!DNSCryptHelper.IsInstalled())
			{
				// not installed
				SentrySdk.AddBreadcrumb($"{nameof(UpdateControls)}: Not installed", nameof(SettingsForm));

				serviceButton.Enabled = false;
				configButton.Enabled = false;
				debugButton.Enabled = false;

				foreach (var pair in _controls)
					pair.Value.Enabled = false;

				configRecommendedButton.Enabled = false;
				configPrivacyButton.Enabled = false;
				saveConfigButton.Enabled = false;
				loadConfigButton.Enabled = false;
			}
			else
			{
				// installed
				SentrySdk.AddBreadcrumb($"{nameof(UpdateControls)}: Installed", nameof(SettingsForm));

				installButton.Text = "Uninstall";

				if (DNSCryptHelper.IsRunning())
				{
					// running
					SentrySdk.AddBreadcrumb($"{nameof(UpdateControls)}: Running", nameof(SettingsForm));

					installButton.Enabled = false;
					serviceButton.Text = "Stop service";
					configButton.Enabled = false;
					debugButton.Enabled = false;

					foreach (var pair in _controls)
						pair.Value.Enabled = false;

					configRecommendedButton.Enabled = false;
					configPrivacyButton.Enabled = false;
					saveConfigButton.Enabled = false;
					loadConfigButton.Enabled = false;
				}
				else
				{
					// not running
					SentrySdk.AddBreadcrumb($"{nameof(UpdateControls)}: Not running", nameof(SettingsForm));
				}

				// load controls
				var config = DNSCryptHelper.LoadConfig();

				foreach (var pair in _controls)
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
			SentrySdk.AddBreadcrumb($"{nameof(installButton_Click)}", nameof(SettingsForm));
			installButton.Enabled = false;

			if (DNSCryptHelper.IsInstalled())
			{
				SentrySdk.AddBreadcrumb($"{nameof(installButton_Click)}: Uninstall", nameof(SettingsForm));
				DNSCryptHelper.Uninstall(progressBar, statusLabel);
			}
			else
			{
				SentrySdk.AddBreadcrumb($"{nameof(installButton_Click)}: Install", nameof(SettingsForm));
				await DNSCryptHelper.Install(progressBar, statusLabel);
			}

			UpdateControls();
		}

		private async void serviceButton_Click(object sender, System.EventArgs e)
		{
			SentrySdk.AddBreadcrumb($"{nameof(serviceButton_Click)}", nameof(SettingsForm));
			serviceButton.Enabled = false;

			if (DNSCryptHelper.IsRunning())
			{
				SentrySdk.AddBreadcrumb($"{nameof(serviceButton_Click)}: Stop service", nameof(SettingsForm));
				await DNSCryptHelper.StopService(progressBar, statusLabel);
			}
			else
			{
				SentrySdk.AddBreadcrumb($"{nameof(serviceButton_Click)}: Start service", nameof(SettingsForm));

				saveConfigButton_Click(saveConfigButton, null);
				await DNSCryptHelper.StartService(progressBar, statusLabel);
			}

			UpdateControls();
		}

		private async void configButton_Click(object sender, System.EventArgs e)
		{
			SentrySdk.AddBreadcrumb($"{nameof(configButton_Click)}", nameof(SettingsForm));

			configButton.Enabled = false;
			await DNSCryptHelper.OpenConfig();
			configButton.Enabled = true;
		}

		private async void debugButton_Click(object sender, System.EventArgs e)
		{
			SentrySdk.AddBreadcrumb($"{nameof(debugButton_Click)}", nameof(SettingsForm));

			debugButton.Enabled = false;
			await DNSCryptHelper.DebugProcess(progressBar, statusLabel);
			debugButton.Enabled = true;
		}

		private void configRecommendedButton_Click(object sender, System.EventArgs e)
		{
			SentrySdk.AddBreadcrumb($"{nameof(configRecommendedButton_Click)}", nameof(SettingsForm));

			foreach (var pair in _controls)
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
			SentrySdk.AddBreadcrumb($"{nameof(configPrivacyButton_Click)}", nameof(SettingsForm));

			foreach (var pair in _controls)
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
			SentrySdk.AddBreadcrumb($"{nameof(saveConfigButton_Click)}", nameof(SettingsForm));

			var config = DNSCryptHelper.LoadConfig();

			foreach (var pair in _controls)
			{
				var setting = (ComboBoxItem) pair.Value.SelectedItem;
				config = pair.Key.SetSetting(config, (string) setting.Value);
			}

			DNSCryptHelper.SaveConfig(config);

			Utilities.ButtonSuccessAnimation(sender);
		}

		private void loadConfigButton_Click(object sender, System.EventArgs e)
		{
			SentrySdk.AddBreadcrumb($"{nameof(loadConfigButton_Click)}", nameof(SettingsForm));

			UpdateControls();

			Utilities.ButtonSuccessAnimation(sender);
		}
	}
}
