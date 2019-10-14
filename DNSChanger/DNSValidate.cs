using DNSChanger.Structs;
using Microsoft.Win32.TaskScheduler;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace DNSChanger
{
	public static class DNSValidate
    {
	    private static readonly string TaskPath = GlobalVars.Name + "-ValidationTask";

        static DNSValidate()
        {
            if (!ValidateAutoStartProcessPath())
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
        
        private static Task Get()
        {
	        return TaskService.Instance.GetTask(TaskPath);
        }

        private static bool ValidateAutoStartProcessPath()
        {
            var tsk = Get();
            if (tsk == null) return true;

            var action = (ExecAction) tsk.Definition.Actions[0];

            return action.Path == Utilities.GetProcessPath();
        }

        public static Interface? GetInterfaceToValidate()
        {
            var tsk = Get();
            if (tsk == null) return null;
			
            var action = (ExecAction) tsk.Definition.Actions[0];

            var match = Regex.Match(action.Arguments, @"-validate ""(?<Interface>.+?)""");
            if (!match.Success) return null;

            return NameToInterface(match.Groups["Interface"].Value);
        }

        public static string GetDnsEntriesToValidate()
        {
            var tsk = Get();
            if (tsk == null) return null;
			
            var action = (ExecAction) tsk.Definition.Actions[0];

            var match = Regex.Match(action.Arguments, @"-validate ""(?<Interface>.+?)"" ""(?<Entries>.+?)""");
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
			Disable();

	        var ts = TaskService.Instance;

	        var task = ts.NewTask();
	        task.Principal.RunLevel = TaskRunLevel.Highest;
	        task.RegistrationInfo.Description = "Performs DNS validation procedure on boot";
	        task.RegistrationInfo.Author = GlobalVars.Name;
	        task.Triggers.Add(new LogonTrigger
	        {
		        Delay = TimeSpan.FromMinutes(1),
				Repetition = new RepetitionPattern(TimeSpan.FromHours(12), TimeSpan.Zero),
				ExecutionTimeLimit = TimeSpan.FromMinutes(1),
				UserId = null,
	        });
	        task.Actions.Add(Utilities.GetProcessPath(), $"-validate \"{@interface.Name}\" \"{AggregateDnsEntries(@interface)}\"");
	        
	        ts.RootFolder.RegisterTaskDefinition(TaskPath, task);
        }

        public static void Disable()
        {
	        TaskService.Instance.RootFolder.DeleteTask(TaskPath, false);
        }

        private static string AggregateDnsEntries(Interface @interface)
        {
            var dnsEntries = NetshHelper.GetDnsEntries(@interface);
            return dnsEntries.Select(e => e.Value).Aggregate((r, v) => r += ";" + v);
        }
    }
}
