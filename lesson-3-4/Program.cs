using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;

namespace lesson_3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var matrix = new string[10, 10];
            var rows = matrix.GetUpperBound(0) + 1;
            var column = matrix.Length / rows;
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < column; j++)
                {
                    matrix[i, j] = "O";
                }
            }

            for (var i = 0; i < 4; i++)
            {
                matrix[i + 2, 5] = "X";
            }

            for (var i = 0; i < 3; i++)
            {
                matrix[2, i] = "X";
                matrix[i, 7] = "X";
            }

            for (var i = 0; i < 2; i++)
            {
                matrix[i + 7, 1] = "X";
                matrix[i + 7, 6] = "X";
                matrix[0, i + 2] = "X";
            }

            for (var i = 0; i < 1; i++)
            {
                matrix[9, i + 8] = "X";
                matrix[4, i + 1] = "X";
                matrix[7, i + 3] = "X";
                matrix[5, i + 8] = "X";
            }

            for (var j = 0; j < 10; j++)
            {
                for (var i = 0; i < 10; i++)
                {
                    if (matrix[j, i] == "X")
                        Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("{0,2}{1,1}", matrix[j, i], "");
                    Console.ResetColor();
                }

                Console.WriteLine();
            }
        }
    }
}