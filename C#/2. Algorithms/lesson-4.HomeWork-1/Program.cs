using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace lesson_4.HomeWork_1
{
    internal static class Program
    {
        private static void Main()
        {
            const int n = 5;
            var stringsArray = new StringsArray(n);
            var hashset = new HashTable(n);
            Fill(stringsArray, hashset, n);
            Find(n, stringsArray.Arrays, hashset.Arrays);
            Console.ReadKey();
        }

        private static void Find(int n, IReadOnlyList<string> stringsArray, ICollection<string> hashsetArrays)
        {
            for (var i = 0; i < 10; i++)
            {
                var ran = new Random();
                var search = stringsArray[ran.Next(0, n - 1)];
                TestFindArray(search, stringsArray);
                TestFindHashSet(search, hashsetArrays);
            }
        }

        private static void TestFindHashSet(string search, ICollection<string> hashsetArrays)
        {
            var sw = Stopwatch.StartNew();
            sw.Start();
            var result = hashsetArrays.Contains(search);
            sw.Stop();
            Console.WriteLine(
                result ? $"HashSet search time: {sw.ElapsedTicks / 10000.0}мс" : $"Not found in HashSet !");
        }

        private static void TestFindArray(string search, IReadOnlyList<string> stringArray)
        {
            var sw = Stopwatch.StartNew();
            sw.Start();
            var result = Array.IndexOf((string[]) stringArray, search);
            sw.Stop();
            Console.WriteLine(
                result >= 0 ? $"Array search time: {sw.ElapsedTicks / 10000.0}мс" : $"Not found in array!");
        }

        private static void Fill(StringsArray stringsArray, HashTable hashset, int n)
        {
            for (var i = 0; i < n; i++)
            {
                var text = Guid.NewGuid().ToString();
                stringsArray.Fill(i, text);
                hashset.Fill(i, text);
            }
        }
    }
}