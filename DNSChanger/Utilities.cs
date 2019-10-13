using System.Diagnostics;
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
	}
}
