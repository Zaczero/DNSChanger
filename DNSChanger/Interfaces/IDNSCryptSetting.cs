using System.Collections.Generic;
using DNSChanger.Enums;
using DNSChanger.Structs;

namespace DNSChanger.Interfaces
{
	public interface IDNSCryptSetting
	{
		string GetSetting(DNSCryptSettingPreference preference = DNSCryptSettingPreference.Recommended);
		IEnumerable<ComboBoxItem> GetSettings(string config);
		
		string GetCurrentSetting(string config);
		string SetSetting(string config, string value);
	}
}
