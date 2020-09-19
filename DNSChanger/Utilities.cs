using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

namespace DNSChanger
{
	public static class Utilities
	{
		public static bool IsAdministrator()
		{
			using (var identity = WindowsIdentity.GetCurrent())
				return new WindowsPrincipal(identity).IsInRole(WindowsBuiltInRole.Administrator);
		}

		private static string GetCurrentProcessPath()
		{
			// ReSharper disable once PossibleNullReferenceException
			return Process.GetCurrentProcess().MainModule.FileName;
		}

		private static string GetCommandLine(this Process process)
		{
			using (var searcher = new ManagementObjectSearcher("SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + process.Id))
			using (var objects = searcher.Get())
				return objects.Cast<ManagementBaseObject>().SingleOrDefault()?["CommandLine"]?.ToString();
		}

		public static void Restart()
		{
			var proc = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = GetCurrentProcessPath(),
					Arguments = Process.GetCurrentProcess().GetCommandLine(),
					UseShellExecute = true,
					Verb = "runas",
				},
			};

			try
			{
				proc.Start();
			}
			catch
			{
				// ignored
			}

			Environment.Exit(0);
		}

		private static bool? _isSystemDarkMode;
		private static bool IsSystemDarkMode()
		{
			if (_isSystemDarkMode.HasValue)
				return _isSystemDarkMode.Value;

			var key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", false);
			if (key == null)
				return false;

			var val = (int) key.GetValue("AppsUseLightTheme", 1);
			return (_isSystemDarkMode = val == 0).Value;
		}

		public static void ApplyThemeToForm(Form form)
		{
			if (!IsSystemDarkMode())
				return;

			// apply dark theme
			form.BackColor = Color.FromArgb(0x20, 0x20, 0x20);
			form.ForeColor = Color.FromArgb(0xF0, 0xF0, 0xF0);

			foreach (Control control in form.Controls)
			{
				switch (control)
				{
					case Button btn:
						btn.FlatStyle = FlatStyle.Flat;
						btn.UseVisualStyleBackColor = false;
						break;
					case TextBox tb:
						tb.BackColor = Color.FromArgb(0x30, 0x30, 0x30);
						tb.ForeColor = Color.FromArgb(0xF0, 0xF0, 0xF0);
						tb.BorderStyle = BorderStyle.FixedSingle;
						break;
					case LinkLabel ll:
						ll.LinkColor = Color.FromArgb(0x1, 0x97, 0xF6);
						ll.ActiveLinkColor = Color.FromArgb(0xDF, 0x29, 0x35);
						break;
				}
			}
		}

		public static void ButtonSuccessAnimation(object sender)
		{
			var btn = sender as Button;
			if (btn == null)
				throw new ArgumentException($"Failed casting '{nameof(sender)}' to '{nameof(Button)}'", nameof(sender));

			var defaultColor = btn.BackColor;
			var animateColor = IsSystemDarkMode() ?
				Color.FromArgb(0x10, 0x50, 0x10) :
				Color.LightGreen;

			if (defaultColor == animateColor)
				return;

			btn.BackColor = animateColor;

			new Thread(() =>
			{
				Thread.Sleep(600);
				btn.BackColor = defaultColor;
			}) {IsBackground = true}.Start();
		}
	}
}
