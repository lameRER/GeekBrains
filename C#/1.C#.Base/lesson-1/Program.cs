using System;
using System.Threading;
using static System.String;

namespace lesson_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Prog();
        }

        private static void Prog()
        {
            try
            {
                string name;
                if (!IsNullOrWhiteSpace(name = ReturnUserName()))
                {
                    Console.WriteLine($"Привет, {name}, сегодня {DateTime.Now:dd.MM.yyyy}");
                }
                else
                {
                    throw new Exception("Необходимо ввести имя пользователя");
                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(2000);
                Prog();
            }
        }
        private static string ReturnUserName()
        {
            Console.Clear();
            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();
            return IsNullOrWhiteSpace(name) ? null : name;
        }
    }
}
