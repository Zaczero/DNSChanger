using System.Collections.Generic;
using DNSChanger.Enums;
using DNSChanger.Interfaces;
using DNSChanger.Structs;

namespace DNSChanger.DNSCryptSettings
{
	public class DNSCryptSetting_fallback_resolvers : IDNSCryptSetting
	{
		private const string Name = "fallback_resolvers";

		public string GetCurrentSetting(string config)
		{
			return DNSCryptHelper.GetCurrentSetting(config, Name);
		}

		public string GetSetting(DNSCryptSettingPreference preference = DNSCryptSettingPreference.Recommended)
		{
			return "['1.1.1.1:53', '1.0.0.1:53']";
		}

		public IEnumerable<ComboBoxItem> GetSettings(string config)
		{
			var currentSetting = GetCurrentSetting(config);
			var setting = GetSetting();

			if (currentSetting == setting)
			{
				return new[]
				{
					new ComboBoxItem("Cloudflare", setting),
				};
			}

			return new[]
			{
				new ComboBoxItem(currentSetting),
				new ComboBoxItem("Cloudflare", setting),
			};
		}

		public string SetSetting(string config, string value)
		{
			return DNSCryptHelper.SetSetting(config, Name, value);
		}
	}
}