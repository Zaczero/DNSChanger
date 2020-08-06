using System.Collections.Generic;
using DNSChanger.Enums;
using DNSChanger.Interfaces;
using DNSChanger.Structs;

namespace DNSChanger.DNSCryptSettings
{
	public class DNSCryptSetting_require_nofilter : IDNSCryptSetting
	{
		private const string Name = "require_nofilter";

		public string GetCurrentSetting(string config)
		{
			return DNSCryptHelper.GetCurrentSetting(config, Name);
		}

		public string GetSetting(DNSCryptSettingPreference preference = DNSCryptSettingPreference.Recommended)
		{
			return "true";
		}

		public IEnumerable<ComboBoxItem> GetSettings(string config)
		{
			return new[]
			{
				new ComboBoxItem("true"),
				new ComboBoxItem("false"),
			};
		}

		public string SetSetting(string config, string value)
		{
			return DNSCryptHelper.SetSetting(config, Name, value);
		}
	}
}