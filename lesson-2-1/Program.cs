using System;
using System.Threading;

namespace lesson_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Consol();
        }
        private static void Consol()
        {
            try
            {
                Console.Write("Введите минимальную температуру за сутки: ");
                double readMinTp = ReadTemp();
                Console.Write("Введите максимальную температуру за сутки: ");
                double readMaxTp = ReadTemp();
                Console.WriteLine();
                Console.WriteLine($"Среднесуточная температура за сутки: {Math.Round((readMaxTp % readMinTp), MidpointRounding.AwayFromZero).ToString().Replace(",", ".")}");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }
        private static double ReadTemp()
        {
            var tp = Convert.ToDouble(Console.ReadLine().Replace(".", ","));
            return tp;
        }
        private static void Error(string ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex);
            Thread.Sleep(2000);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Consol();
        }
    }
}
