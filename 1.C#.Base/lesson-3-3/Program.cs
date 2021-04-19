using System;
using System.Diagnostics;

namespace lesson_3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            StartConsole();
        }

        private static void StartConsole()
        {
            try
            {
                var readtext = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(readtext))
                {
                    Console.WriteLine("Результат: " + Revers(readtext));
                }
                else
                {
                   throw new Exception("Строка не может быть пустой!");
                }
            }
            catch (Exception e)
            {
                ConsoleColor(e.Message);
                Debug.WriteLine(e);
            }
            finally
            {
                StartConsole();
            }
        }

        private static void ConsoleColor(string eMessage)
        {
            Console.ForegroundColor = System.ConsoleColor.Red;
            Console.WriteLine(eMessage);
            Console.ResetColor();
        }

        private static string Revers(string s)
        {
            var revers = string.Empty;
            for (var i = s.Length - 1; i >= 0; i--) revers += s[i];
            return revers;
        }
    }
}