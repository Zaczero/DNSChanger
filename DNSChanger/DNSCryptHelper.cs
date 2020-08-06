using DNSChanger.Structs;
using DnsClient;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DNSChanger
{
	public static class DNSCryptHelper
	{
		private const string DNSCryptRelease = "2.0.44";
		
		private static readonly string UnzipDirectory =
			Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
				"DNSCrypt"
			);

		private static readonly string InstallationDirectory =
			Path.Combine(
				UnzipDirectory,
				"win" + (Environment.Is64BitProcess ? "64" : "32")
			);

		private static readonly string BinaryPath =
			Path.Combine(
				InstallationDirectory,
				"dnscrypt-proxy.exe"
			);

		private static readonly string ConfigPath =
			Path.Combine(
				InstallationDirectory,
				"dnscrypt-proxy.toml"
			);

		private static readonly string ConfigExamplePath =
			Path.Combine(
				InstallationDirectory,
				"example-dnscrypt-proxy.toml"
			);

		public static bool IsInstalled()
		{
			if (!Directory.Exists(InstallationDirectory))
				return false;

			if (!File.Exists(BinaryPath))
				return false;

			if (!File.Exists(ConfigPath))
				return false;

			return true;
		}

		public static bool IsRunning()
		{
			try
			{
				var endpoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 53);
				var client = new LookupClient(new LookupClientOptions(endpoint)
				{
					Retries = 0,
					Timeout = TimeSpan.FromMilliseconds(200),
				});

				client.Query("github.com", QueryType.A);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static DNSServerEntry GetDNSServer()
		{
			return new DNSServerEntry
			{
				Name = "DNSCrypt",
				DnsEntries = new[]
				{
					new DNSEntry("127.0.0.1"),
				},
			};
		}

		public static async Task<bool> Install(ProgressBar progressBar, Label statusLabel)
		{
			progressBar.Minimum = 0;
			progressBar.Maximum = 1;
			progressBar.Value = 0;
			progressBar.Style = ProgressBarStyle.Marquee;
			statusLabel.Text = "Initializing installation process...";

			var handler = new HttpClientHandler
			{
				AllowAutoRedirect = true,
				AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
			};

			var http = new HttpClient(handler);
			var bits = Environment.Is64BitProcess ? "64" : "32";
			byte[] buffer;

			try
			{
				statusLabel.Text = $"Downloading dnscrypt-proxy {DNSCryptRelease} (x{bits}) from GitHub...";
				buffer = await http.GetByteArrayAsync($"https://github.com/DNSCrypt/dnscrypt-proxy/releases/download/{DNSCryptRelease}/dnscrypt-proxy-win{bits}-{DNSCryptRelease}.zip");
			}
			catch (Exception ex)
			{
				statusLabel.Text = $"[!] Exception: {ex.Message}";
				return false;
			}
			
			statusLabel.Text = "Extracting files (1/3)...";
			if (Directory.Exists(UnzipDirectory))
				Directory.Delete(UnzipDirectory, true);

			Directory.CreateDirectory(UnzipDirectory);

			statusLabel.Text = "Extracting files (2/3)...";
			var tempPath = Path.GetTempFileName() + ".zip";
			File.WriteAllBytes(tempPath, buffer);
				
			statusLabel.Text = "Extracting files (3/3)...";
			ZipFile.ExtractToDirectory(tempPath, UnzipDirectory);
			File.Delete(tempPath);

			statusLabel.Text = "Setting up...";
			File.Copy(ConfigExamplePath, ConfigPath, true);
			
			progressBar.Value = 1;
			progressBar.Style = ProgressBarStyle.Continuous;
			statusLabel.Text = "Installation successful.";
			return true;
		}

		public static bool Uninstall(ProgressBar progressBar, Label statusLabel)
		{
			progressBar.Minimum = 0;
			progressBar.Maximum = 1;
			progressBar.Value = 0;
			progressBar.Style = ProgressBarStyle.Marquee;
			statusLabel.Text = "Deleting DNSCrypt files...";

			try
			{
				Directory.Delete(UnzipDirectory, true);
			}
			catch (Exception ex)
			{
				statusLabel.Text = $"[!] Exception: {ex.Message}";
				return false;
			}
			
			progressBar.Value = 1;
			progressBar.Style = ProgressBarStyle.Continuous;
			statusLabel.Text = "Uninstallation successful.";
			return true;
		}

		public static async Task StartService(ProgressBar progressBar, Label statusLabel)
		{
			progressBar.Minimum = 0;
			progressBar.Maximum = 1;
			progressBar.Value = 0;
			progressBar.Style = ProgressBarStyle.Marquee;
			statusLabel.Text = "Installing DNSCrypt service...";

			await Task.Run(() =>
			{
				ExecuteProcessHidden(BinaryPath, "-service install");
			});

			statusLabel.Text = "Starting DNSCrypt service...";

			await Task.Run(() =>
			{
				ExecuteProcessHidden(BinaryPath, "-service start");
			});

			var counter = 1;

			while (!IsRunning())
			{
				statusLabel.Text = $"Starting DNSCrypt service ({counter++} s)...";
				await Task.Delay(TimeSpan.FromSeconds(1));
			}

			progressBar.Value = 1;
			progressBar.Style = ProgressBarStyle.Continuous;
			statusLabel.Text = "Service start successful.";
		}

		public static async Task StopService(ProgressBar progressBar, Label statusLabel)
		{
			progressBar.Minimum = 0;
			progressBar.Maximum = 1;
			progressBar.Value = 0;
			progressBar.Style = ProgressBarStyle.Marquee;
			statusLabel.Text = "Stopping DNSCrypt service...";

			await Task.Run(() =>
			{
				ExecuteProcessHidden(BinaryPath, "-service stop");
			});

			statusLabel.Text = "Uninstall DNSCrypt service...";

			await Task.Run(() =>
			{
				ExecuteProcessHidden(BinaryPath, "-service uninstall");
			});

			progressBar.Value = 1;
			progressBar.Style = ProgressBarStyle.Continuous;
			statusLabel.Text = "Service stop successful.";
		}

		public static async Task OpenConfig()
		{
			await Task.Run(() =>
			{
				ExecuteProcess(ConfigPath);
			});
		}

		public static async Task DebugProcess(ProgressBar progressBar, Label statusLabel)
		{
			progressBar.Minimum = 0;
			progressBar.Maximum = 1;
			progressBar.Value = 0;
			progressBar.Style = ProgressBarStyle.Marquee;
			statusLabel.Text = "Debugging DNSCrypt process...";

			await Task.Run(() =>
			{
				ExecuteProcess(BinaryPath);
			});

			progressBar.Value = 1;
			progressBar.Style = ProgressBarStyle.Continuous;
			statusLabel.Text = "Debug process successful.";
		}

		public static void SaveConfig(string config)
		{
			File.WriteAllText(ConfigPath, config);
		}

		public static string LoadConfig()
		{
			return File.ReadAllText(ConfigPath);
		}

		public static string GetCurrentSetting(string config, string name)
		{
			var match = new Regex($@"^(?:# )?{name} =\s*(?<value>.*?)\s*$", RegexOptions.Multiline).Match(config);
			if (!match.Success)
				return string.Empty;

			return match.Groups["value"].Value;
		}

		public static string SetSetting(string config, string name, string value)
		{
			var match = new Regex($@"^(?:# )?{name} =\s*(?<value>.*?)\s*$", RegexOptions.Multiline).Match(config);
			if (!match.Success)
			{
				if (!config.EndsWith(Environment.NewLine))
					config += Environment.NewLine;

				return config + $"{name} = {value}{Environment.NewLine}";
			}

			var index = match.Groups[0].Index;
			var length = match.Groups[0].Length;

			return config.Substring(0, index) + $"{name} = {value}{Environment.NewLine}" + config.Substring(index + length);
		}

		private static void ExecuteProcessHidden(string path, string arguments = "")
		{
			var psi = new ProcessStartInfo
			{
				Arguments = arguments,
				CreateNoWindow = true,
				UseShellExecute = false,
				FileName = path,
				WorkingDirectory = Path.GetDirectoryName(path),
				WindowStyle = ProcessWindowStyle.Hidden,
				Verb = "runas",
			};

			var process = new Process {StartInfo = psi};

			process.Start();
			process.WaitForExit();
		}

		private static void ExecuteProcess(string path, string arguments = "")
		{
			var process = Process.Start(path, arguments);

			process.WaitForExit();
		}
	}
}
