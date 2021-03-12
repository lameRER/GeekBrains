using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Channels;

namespace lesson_5_3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            StartUp();
            Console.ReadLine();
        }

        private static void StartUp()
        {
            try
            {                
                var hashFileOld = string.Empty;
                Console.Write("Введите число от 0 до 255: ");
                const string file = "Number.bin";
                if (File.Exists($"{Directory.GetCurrentDirectory()}/{file}"))
                    hashFileOld = CalculateMd5Hash(file);
                if (!int.TryParse(Console.ReadLine(), out var readNumber) || readNumber >= 255 || readNumber <= 0)
                    throw new Exception("Введите число от 0 до 255");
                var formatter = new BinaryFormatter();
                formatter.Serialize(new FileStream(file, FileMode.OpenOrCreate), readNumber);
                var hashFileNew = CalculateMd5Hash(file);
                Console.WriteLine($"Файл '{file}' {ComparisonFileHash(hashFileNew, hashFileOld)}");
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                StartUp();
            }
        }

        private static string ComparisonFileHash(string hashFileNew, string hashFileOld)
        {
            if (hashFileOld == string.Empty)
                return "Создан";
            else if(hashFileNew == hashFileOld)
                return "Не изменен";
            else
                return "Изменен";
        }
        
        private static string CalculateMd5Hash(string filename)
        {
            using var md5 = MD5.Create();
            using var stream = File.OpenRead(filename);
            var hash = md5.ComputeHash(stream);
            return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
        }
    }
}
