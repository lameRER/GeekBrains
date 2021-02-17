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
            var password = new int[random.Next(10, 30)];
            for (var i = 0; i < password.Length; i++)
            {
                Thread.Sleep(250);
                string tempPassword = null;
                var accessPw = true;
                password[i] = random.Next(10, 999999);
                foreach (var y in password[i].ToString())
                {
                    tempPassword += y;
                    if (random.Next(1, 100) >= 15) continue;
                    tempPassword = tempPassword.Remove(tempPassword.Length-1);
                    tempPassword += Convert.ToString((char)('a' + random.Next(0, 26)));
                    accessPw = false;
                }
                var charTemp = '\0';
                if (tempPassword != null)
                    foreach (var t in tempPassword)
                    {
                        if (charTemp == t)
                        {
                            charTemp = t;
                            accessPw = false;
                            Console.Write(t);
                        }
                        else
                        {
                            charTemp = t;
                            Console.Write(t);
                        }
                    }
                Console.ForegroundColor = accessPw ? ConsoleColor.Green : ConsoleColor.Red;
                Console.Write($"\t\t {accessPw}");
                Console.ResetColor();
                Console.WriteLine();
            }
            Thread.Sleep(1500);
            Console.Clear();
        }
    }
}
