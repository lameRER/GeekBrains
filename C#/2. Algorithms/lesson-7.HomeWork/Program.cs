using System;
using System.Threading;

namespace lesson_7.HomeWork
{
    internal static class Program
    {
        private const int N = 8;
        private const int M = 8;
        private static void Main()
        {
            var resultRecursive = PrintRecursive(N, M, 4);
            Console.WriteLine();
            Console.WriteLine("Recursive: {0}",resultRecursive);
            Console.WriteLine();
            var resultFor = PrintFor(N,M,3);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("For: {0}",resultFor);
            PrintConsole(N, M);
        }

        private static void PrintConsole(int n, int m)
        {
            var matrix = new int[m, n];
            for (var i = 0; i < M; i++) matrix[0, i] = 1;
            for (var i = 1; i < N; i++)
            {
                matrix[i, 0] = 1;
                for (var j = 1; j < M; j++) matrix[i, j] = matrix[i, j - 1] + matrix[i - 1, j];
            }
            Console.WriteLine("Результат: {0}", matrix[n - 1, m - 1]);
        }

        private static int PrintRecursive(int m, int n, int offsetY)
        {
            var result = m == 1 || n == 1 ? 1 : PrintRecursive(m, n - 1, offsetY) + PrintRecursive(m - 1, n, offsetY);
            Console.SetCursorPosition((n-1)*8, (m+ offsetY));
            Console.Write(result);
            return result;
        }

        private static int PrintFor(int m, int n, int offsetY)
        {
            var matrix = new int[m, n];
            for (var i = 0; i < m; i++)
            for (var j = 0; j < n; j++)
            {
                if (i != 0 || j != 0)
                {
                    matrix[i, j] = i == 0 || j == 0 ? 1 : matrix[i - 1, j] + matrix[i, j - 1];
                }
                else
                    matrix[i, j] = 0;
                Console.SetCursorPosition((j) * 8, (i + offsetY));
                Console.Write(matrix[i, j]);
            }
            return matrix[m-1, n-1];
        }
    }
}
