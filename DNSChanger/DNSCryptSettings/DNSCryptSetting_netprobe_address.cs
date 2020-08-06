using System.Collections.Generic;
using DNSChanger.Enums;
using DNSChanger.Interfaces;
using DNSChanger.Structs;

namespace DNSChanger.DNSCryptSettings
{
	public class DNSCryptSetting_netprobe_address : IDNSCryptSetting
	{
		private const string Name = "netprobe_address";

		public string GetCurrentSetting(string config)
		{
			return DNSCryptHelper.GetCurrentSetting(config, Name);
		}

		public string GetSetting(DNSCryptSettingPreference preference = DNSCryptSettingPreference.Recommended)
		{
			return "'1.1.1.1:53'";
		}

		public IEnumerable<ComboBoxItem> GetSettings(string config)
		{
			var currentSetting = GetCurrentSetting(config);
			var setting = GetSetting();

			if (currentSetting == setting)
			{
				return new[]
				{
					new ComboBoxItem("Cloudflare", "'1.1.1.1:53'"),
				};
			}

			return new[]
			{
				new ComboBoxItem(currentSetting),
				new ComboBoxItem("Cloudflare", "'1.1.1.1:53'"),
			};
		}

		public string SetSetting(string config, string value)
		{
			return DNSCryptHelper.SetSetting(config, Name, value);
		}
	}
}