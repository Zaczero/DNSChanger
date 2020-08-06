using System.Diagnostics;
using System.IO;

namespace DNSChanger
{
	public static class DNSCryptHelper
	{
		private static void ExecuteProcess(string path, string arguments = "")
		{
			var psi = new ProcessStartInfo
			{
				Arguments = arguments,
				CreateNoWindow = true,
				UseShellExecute = false,
				FileName = path,
				WorkingDirectory = Path.GetDirectoryName(path),
				WindowStyle = ProcessWindowStyle.Hidden,
			};

			var process = new Process {StartInfo = psi};

			process.Start();
			process.WaitForExit();
		}
	}
}
