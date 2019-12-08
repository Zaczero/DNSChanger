using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Security.Principal;
using Microsoft.Win32;

namespace DNSChanger
{
	public static class Utilities
	{
		public static bool IsAdministrator()
		{
			using (var identity = WindowsIdentity.GetCurrent())
			{
				var principal = new WindowsPrincipal(identity);
				return principal.IsInRole(WindowsBuiltInRole.Administrator);
			}
		}

		public static string GetProcessPath()
		{
			return Process.GetCurrentProcess().MainModule.FileName;
		}

		public static string GetCommandLine(this Process process)
		{
			using (var searcher = new ManagementObjectSearcher("SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + process.Id))
			using (var objects = searcher.Get())
			{
				return objects.Cast<ManagementBaseObject>().SingleOrDefault()?["CommandLine"]?.ToString();
			}
		}

		private static bool? _isSystemDarkMode;
		public static bool IsSystemDarkMode()
		{
			if (_isSystemDarkMode.HasValue) return _isSystemDarkMode.Value;

			var key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", false);
			if (key == null) return false;

			var val = (int) key.GetValue("AppsUseLightTheme", 1);
			return (_isSystemDarkMode = val == 0).Value;
		}
	}
}
