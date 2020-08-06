using System.Collections.Generic;
using DNSChanger.Enums;
using DNSChanger.Interfaces;
using DNSChanger.Structs;

namespace DNSChanger.DNSCryptSettings
{
	public class DNSCryptSetting_tls_disable_session_tickets : IDNSCryptSetting
	{
		private const string Name = "tls_disable_session_tickets";

		public string GetCurrentSetting(string config)
		{
			return DNSCryptHelper.GetCurrentSetting(config, Name);
		}

		public string GetSetting(DNSCryptSettingPreference preference = DNSCryptSettingPreference.Recommended)
		{
			if (preference == DNSCryptSettingPreference.Privacy)
				return "true";

			return "false";
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