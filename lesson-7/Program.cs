using System;
using System.IO;

namespace lesson_7
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in Directory.GetDirectories(@"C:\"))
            {
                Console.WriteLine(item);
            }
            
            Console.ReadLine();
        }
    }
}
