using System;
using System.Diagnostics;

namespace lesson_3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var matrix = new int[10,10];
                var rows = matrix.GetUpperBound(0) + 1;
                var column = matrix.Length / rows;
                for (var i = 0; i < rows; i++)
                {
                    for (var j = 0; j < column; j++)
                    {
                        matrix[i, j] = j + i;
                    }
                }
                for (var i = 0; i < rows; i++)
                {
                    for (var j = 0; j < column; j++)
                    {
                        if (i != j)
                        {
                            if (i > j)
                            {
                                Console.ForegroundColor = (ConsoleColor) i - j+2;
                            }
                            else if(i < j)
                            {
                                Console.ForegroundColor = (ConsoleColor) j - i+2;
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }

                        Console.Write("\t" + matrix[i, j]);
                        Console.ResetColor();
                    }
                    Console.WriteLine("\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Debug.WriteLine(e);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}