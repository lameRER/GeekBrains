using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Channels;



namespace lesson_6
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                if (args.Length > 0)
                {
                    var regex = new Regex(@"^(-|/)" + args[0].Remove(0, 1));
                    if (regex.Match(args[0]).Value.ToUpper().Contains("TASKLIST"))
                        new TaskList(args);
                    else if (regex.Match(args[0]).Value.ToUpper().Contains("TASKKILL"))
                        new TaskKill(args);
                    else
                        MethodErrors.Error(new ArgumentException("invalid argument!"));
                }
                else
                {
                    MethodErrors.Error(new ArgumentException("invalid argument!"));
                }
            }
            catch (Exception e)
            {
                MethodErrors.Error(e);
            }
        }
    }
}
