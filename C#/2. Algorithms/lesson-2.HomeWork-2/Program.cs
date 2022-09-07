using System;

namespace lesson_2.HomeWork_2
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var ran = new Random();
            const int n = 10000000;
            var arr = new int[n];
            for (var i = 0; i < arr.Length; i++) arr[i] = ran.Next(1, n);
            Array.Sort(arr);
            for (var i = 0; i < 40; i++)
            {
                var (index, countIteration) = BinarySearch(arr, ran.Next(1, n));
                Console.WriteLine(index == -1
                    ? $"Значение {ran.Next(1, n)} не найдено, количество интеграций: {countIteration}"
                    : $"Значение {ran.Next(1, n)}, индекс: {index}, количество интеграций: {countIteration}");
            }
            
        }

        private static (int index, int countIteration) BinarySearch(int[] inputArray, int searchValue)
        {
            var countIteration = 0;
            var min = 0;
            var max = inputArray.Length - 1;
            while (min <= max)
            {
                var mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                    return (mid, countIteration);
                else if (searchValue < inputArray[mid])
                    max = mid - 1;
                else
                    min = mid + 1;
                countIteration++;
            }
            return (-1, countIteration);
        }
    }
}