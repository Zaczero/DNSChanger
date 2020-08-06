using System.Collections.Generic;
using DNSChanger.Enums;
using DNSChanger.Interfaces;
using DNSChanger.Structs;

namespace DNSChanger.DNSCryptSettings
{
	public class DNSCryptSetting_reject_ttl : IDNSCryptSetting
	{
		private const string Name = "reject_ttl";

		public string GetCurrentSetting(string config)
		{
			return DNSCryptHelper.GetCurrentSetting(config, Name);
		}

		public string GetSetting(DNSCryptSettingPreference preference = DNSCryptSettingPreference.Recommended)
		{
			return "3600";
		}

		public IEnumerable<ComboBoxItem> GetSettings(string config)
		{
			var currentSetting = GetCurrentSetting(config);
			var setting = GetSetting();
			
			// TODO: support more than 1 builtin setting
			if (currentSetting == setting)
			{
				return new[]
				{
					new ComboBoxItem(setting),
				};
			}

			return new[]
			{
				new ComboBoxItem(currentSetting),
				new ComboBoxItem(setting),
			};
		}

		public string SetSetting(string config, string value)
		{
			return DNSCryptHelper.SetSetting(config, Name, value);
		}
	}
}