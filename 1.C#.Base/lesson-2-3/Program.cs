using System;
using System.Data;
using static System.String;

namespace lesson_2_3
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
                string number;
                Console.Write("Введите число: ");
                if (!IsNullOrWhiteSpace(number = Console.ReadLine()))
                {
                    int int32 = Convert.ToInt32(number);
                    Console.WriteLine(Check(CheckEven(int32)));
                }
                else
                {
                    throw new Exception("Необходимо ввести значение");
                }
            }
            catch (Exception e)
            {
                Error(e.Message);
            }
            finally
            {
                Console.ResetColor();
                StartConsole();
            }
        }

        private static void Error(string eMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(eMessage);
            Console.ResetColor();
        }

        private static bool Check(bool check)
        {
            switch (check)
            {
                case true:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case false:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
            return check;
        }

        private static bool CheckEven(int readLine)
        {
            return (readLine % 2) == 0;
        }
    }
}
