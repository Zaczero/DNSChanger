using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Security.Principal;

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
	}
}
