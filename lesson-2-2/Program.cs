using System;

namespace lesson_2_2
{
    class Program
    {
        private enum Months
        {
            January = 1,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }
        static void Main(string[] args)
        { 
            StartConsole();
        }

        private static void StartConsole()
        {
            try
            {
                Console.Write("Введите порядковый номер месяца: ");
                Console.ForegroundColor = ConsoleColor.Green;
                var read = Convert.ToInt16(Console.ReadLine());
                if (read >= 12) return;
                Console.WriteLine($"Результат: {Month_result(read)}");
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

        private static Months Month_result(int readMonth)
        {
            var months = (Months) readMonth;
            return months;
        }
        

        private static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            StartConsole();
        }
    }
}
