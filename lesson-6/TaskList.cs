using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_6
{
    internal class TaskList : ArgumentsList
    {
        public TaskList(string[] args)
        {
            try
            {
                if (args.Length == 1) GetProcessList();
                else if (args.Length == 2 || args[1].ToUpper() == "/F") GetProcessList(args[2]);
                else MethodErrors.Error(new  ArgumentException("invalid argument!"));
            }
            catch (Exception e)
            {
                MethodErrors.Error(e);
            }
        }
        private void GetProcessList()
        {
            try
            {
                var processes = Process.GetProcesses();
                Rendering(processes);
            }
            catch (Exception e)
            {
                MethodErrors.Error(e);
            }
        }

        private void GetProcessList(string argument)
        {
            try
            {
                var processes = Process.GetProcessesByName(argument);
                Rendering(processes);
            }
            catch (Exception e)
            {
                MethodErrors.Error(e);
            }
        }

        private static void Rendering(Process[] processes)
        {
            try
            {
                Console.WriteLine("{0,-20}{1,14}{2,12}{3,13}", "Image Name", "PID", "Session#", "Mem Usage");
                Console.WriteLine("{0,-20}{1,9}{2,12}{3,13}", "=========================", "========", "===========", "============");
                foreach (var process in processes)
                {
                    var processName = process.ProcessName.Length > 20 ? process.ProcessName.Remove(20) : process.ProcessName;
                    Console.WriteLine("{0,-20}{1,14}{2,12}{3,13}", processName, process.Id, process.SessionId, process.PeakPagedMemorySize64);
                }
            }
            catch (Exception e)
            {
                MethodErrors.Error(e);
            }
        }
    }
}
