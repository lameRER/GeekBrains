using System;
using System.Threading;

namespace Additional_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                prog();
            }
        }

        private static void prog()
        {
            var random = new Random();
            var password = new int[random.Next(10, 20)];
            for (var i = 0; i < password.Length; i++)
            {
                Thread.Sleep(250);
                var RanTemp = password[i] = random.Next(1000, 999999);
                var CharTemp = '\0';
                var AccessPw = true;
                foreach (var t in RanTemp.ToString())
                {
                    if (CharTemp == t)
                    {
                        CharTemp = t;
                        AccessPw = false;
                        Console.Write(t);
                    }
                    else
                    {
                        CharTemp = t;
                        Console.Write(t);
                    }
                }
                Console.ForegroundColor = AccessPw ? ConsoleColor.Green : ConsoleColor.Red;
                Console.Write($"\t {AccessPw}");
                Console.ResetColor();
                Console.WriteLine();
            }
            Thread.Sleep(1500);
            Console.Clear();
        }
    }
}
