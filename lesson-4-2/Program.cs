using System;
using System.Globalization;
using System.Linq;
using System.Threading.Channels;

namespace lesson_4_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true) StartConsole();
        }

        private static void StartConsole()
        {
            try
            {
                Write(Sum());
            }
            catch (Exception e)
            {
                Error(e.Message);
            }
        }

        private static int Sum()
        {
            return GetNumeric().Sum();
        }

        private static void Write(int s)
        {
            Console.WriteLine("Результат: {0}", s);
        }

        private static int[] GetNumeric()
        {
            Console.WriteLine("Введите число(а) через пробел: ");
            return GetArrayInt(GetArrayString(Console.ReadLine()));
        }

        private static string[] GetArrayString(string readLine)
        {
            return readLine.Split(' ');
        }

        private static int[] GetArrayInt(string[] getArrayString)
        {
            var intArray = new int[getArrayString.Length];

            for (var i = 0; i < getArrayString.Length; i++)
                if (int.TryParse(getArrayString[i], out intArray[i]))
                    int.TryParse(getArrayString[i], out intArray[i]);
                else
                    throw new Exception("Необходимо ввести число!");
            return intArray;
        }

        private static void Error(string ex)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex);
            Console.ResetColor();
        }
    }
}