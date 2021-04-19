using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_6
{
    internal class ArgumentsList
    {
        protected static void GetList()
        {
            Console.WriteLine("Parameter List:");
            Console.WriteLine("{0,5}{1,0}{2,43}", "", "/TASKLIST", "Displaying a list of processes");
            Console.WriteLine("{0,5}{1,0}{2,43}", "", "/TASKLIST /F", "search process by name");
            Console.WriteLine("{0,5}{1,0}{2,38}", "", "/TASKKILL", "Completion of the process");
            Console.WriteLine("{0,5}{1,0}{2,41}", "", "/TASKKILL /PID", "Termination of the process by PID");
            Console.WriteLine("{0,5}{1,0}{2,40}", "", "/TASKKILL /IMAGENAME", "Completion of the process by IMAGENAME");
        }
    }
}
