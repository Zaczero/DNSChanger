using DNSChanger.Structs;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace DNSChanger
{
    public static class DNSValidate
    {
        private static readonly RegistryKey RegistryKey;

        static DNSValidate()
        {
            if (Environment.Is64BitOperatingSystem)
            {
                RegistryKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Run", true);
            }
                
            if(RegistryKey == null)
            {
                RegistryKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
            }

            if (!VerifyProcessPath())
            {
                var @interface = GetInterfaceToValidate();
                if (@interface.HasValue)
                {
                    Enable(@interface.Value);
                }
            }
        }

        public static bool ProcessArgs(string[] args)
        {
            for (var i = 0; i < args.Length; i++)
            {
                if (args[i] == "-validate" && i + 2 < args.Length)
                {
                    var @interface = NameToInterface(args[i + 1]);
                    if (@interface.HasValue)
                    {
                        var savedDnsEntries = args[i + 2].Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var dnsEntry in NetshHelper.GetDnsEntries(@interface.Value))
                        {
                            if (!savedDnsEntries.Contains(dnsEntry.Value))
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }
        
        private static string Get()
        {
            return (string) RegistryKey.GetValue(GlobalVars.Name);
        }

        private static bool VerifyProcessPath()
        {
            var val = Get();
            if (val == null) return true;

            var path = Process.GetCurrentProcess().MainModule.FileName;
            return val.StartsWith($"\"{path}\"");
        }

        public static Interface? GetInterfaceToValidate()
        {
            var val = Get();
            if (val == null) return null;

            var match = Regex.Match(val, @"-validate ""(?<Interface>.+?)""");
            if (!match.Success) return null;

            return NameToInterface(match.Groups["Interface"].Value);
        }

        public static string GetDnsEntriesToValidate()
        {
            var val = Get();
            if (val == null) return null;

            var match = Regex.Match(val, @"-validate ""(?<Interface>.+?)"" ""(?<Entries>.+?)""");
            if (!match.Success) return null;

            return match.Groups["Entries"].Value;
        }

        private static Interface? NameToInterface(string name)
        {
            var interfaces = NetshHelper.GetInterfaces();

            try
            {
                return interfaces.First(i => i.Name == name);
            }
            catch
            {
                return null;
            }
        }

        public static void Enable(Interface @interface)
        {
            RegistryKey.SetValue(GlobalVars.Name, $"\"{Process.GetCurrentProcess().MainModule.FileName}\" -validate \"{@interface.Name}\" \"{AggregateDnsEntries(@interface)}\"");
        }

        public static void Disable()
        {
            if (Get() != null)
            {
                RegistryKey.DeleteValue(GlobalVars.Name);
            }
        }

        private static string AggregateDnsEntries(Interface @interface)
        {
            var dnsEntries = NetshHelper.GetDnsEntries(@interface);
            return dnsEntries.Select(e => e.Value).Aggregate((r, v) => r += ";" + v);
        }
    }
}
