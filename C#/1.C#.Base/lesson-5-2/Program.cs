using System.Text;
using System.IO;
using System;
using System.Threading;

namespace lesson_5_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var file = "startup.txt";
            File.AppendAllText(file, DateTime.Now.ToString());
            
            
            //Альтернативный вариант
            // var file = "startup.txt";
            // using var sWriter = new StreamWriter(file, true, Encoding.Default);
            // sWriter.WriteLine(DateTime.Now);
        }
    }
}
