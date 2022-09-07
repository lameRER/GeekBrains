using System;
using System.Drawing;
using System.IO;

namespace lesson_4_3
{
    internal enum Season
    {
        Winter = 1, 
        Spring, 
        Summer, 
        Autumn
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            StartConsole();
        }

        private static void StartConsole()
        {
            WriteText("Введите чило месяца: ");
            try
            {
                if (!int.TryParse(Console.ReadLine(), out var outNumber) || outNumber > 12 || outNumber < 1) throw new Exception("Ошибка: введите число от 1 до 12");

                WriteText(GetSeason(GetDeterminingSeason(outNumber)), ConsoleColor.Green);
            }
            catch (Exception e)
            {
                WriteText(e.Message, ConsoleColor.Red);
            }
            finally
            {
                StartConsole();
            }
        }

        private static int GetDeterminingSeason(int number)
        {
            switch (number)
            {
                case 12:
                case 1:
                case 2:
                    return 1;
                case 3:
                case 4:
                case 5:
                    return 2;
                case 6:
                case 7:
                case 8:
                    return 3;
                case 9:
                case 10:
                case 11:
                    return 4;
                default:
                    return 0;
            }
        }
        
        private static Season GetSeason(int readSeason)
        {
            var season = (Season) readSeason;
            return season;
        }

        private static void WriteText(string text, ConsoleColor color = default)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
        }
        private static void WriteText(Season text, ConsoleColor color = default)
        {
            Console.Clear();
            Console.ForegroundColor = color;
            Console.WriteLine("Результат: {0}",text);
        }
    }
}
