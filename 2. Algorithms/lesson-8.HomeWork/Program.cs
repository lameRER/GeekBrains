using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using lesson_4.HomeWork.Library;
using lesson_4.HomeWork.Library.Sort;

namespace lesson_8.HomeWork
{
    internal static class Program
    {
        private static void Main()
        {
            var rnd = new Random();
            var items = new List<int>();
            for (int i = 0; i < 20; i++)
            {
                items.Add(rnd.Next(0,100));
            }
            foreach (var item in items)
            {
                Console.Write("{0} ", item);
            }

            GetSort("BubbleSort", new BubbleSort<int>(), items);
            GetSort("CocktailSort", new CocktailSort<int>(), items);
        }

        private static void GetSort(string sortName, AlgorithmBase<int> baseSort, IEnumerable<int> items)
        {
            var stopwatch = new Stopwatch();
            baseSort.Items.AddRange(items);
            stopwatch.Start();
            baseSort.Sort();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("{0}: SwopCount:{2} {1}", sortName, stopwatch.Elapsed, baseSort.SwopCount);
            stopwatch.Stop();
            foreach (var item in baseSort.Items)
            {
                Console.Write("{0} ", item);
            }
        }
    }
}