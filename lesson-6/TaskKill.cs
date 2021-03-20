using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_6
{
    internal class TaskKill : ArgumentsList
    {
        public TaskKill(string[] args)
        {
            if (args[1].ToUpper() == "/PID" || int.TryParse(args[2], out _))
            {
                int.TryParse(args[2], out var pid);
                KillProcess(pid);
            }
            else if (args[1].ToUpper() == "/IMAGENAME")
            {
                KillProcess(args[2]);
            }
            else
            {
                MethodErrors.Error(new ArgumentException("invalid argument!"));
            }
        }
        private void KillProcess(int pid)
        {
            try
            {
                var process = Process.GetProcessById(pid);
                process.Kill();
            }
            catch (Exception e)
            {
                MethodErrors.Error(e);
            }
        }
        private void KillProcess(string imageName)
        {
            try
            {
                var process = Process.GetProcessesByName(imageName);
                process[0].Kill();
            }
            catch (Exception e)
            {
                MethodErrors.Error(e);
            }
        }
    }
}
