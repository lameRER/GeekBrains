using System;
using System.IO;
using System.Text;

namespace lesson_5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                StartUp();
            }
        }

        private static void StartUp()
        {
            Console.Write("Введите текст: ");
            File.WriteAllText("File.txt", Console.ReadLine(), Encoding.UTF8);
        }
    }
}