using System;

namespace lesson_1.HomeWork_2
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0;                                            //O(1)

            for (int i = 0; i < inputArray.Length; i++)             //O(inputArray.Length)
            {
                for (int j = 0; j < inputArray.Length; j++)         //O(inputArray.Length)
                {
                    for (int k = 0; k < inputArray.Length; k++)     //O(inputArray.Length)
                    {
                        int y = 0;                                  

                        if (j != 0)
                        {
                            y = k / j;                              
                        }

                        sum += inputArray[i] + i + k + j + y;       
                    }
                }
            }

            return sum;                                             //O(1)
        }

        // O(2) + O(inputArray.Length * inputArray.Length * inputArray.Length)
    }
}