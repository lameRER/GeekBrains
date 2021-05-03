using System;

namespace lesson_4.HomeWork_2
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 10;
            var ran = new Random();
            var values = new int[n];
            for (var i = 0; i < n; i++)
            {
                var ranVal = ran.Next(1, n+1);
                // if (i == n - 1)
                    // ranVal = n;
                SetValue(values, ref ranVal, n+1);
                values[i] = ranVal;
            }
            var bList = new BidirectionalList();
            foreach (var item in values)
            {
                bList.AddNode(item);
            }
            
        }

        static void SetValue(int[] values, ref int val, int i)
        {
            var ran = new Random();
            foreach (var value in values)
            {
                if (value == val)
                {
                    val = ran.Next(1, i);
                    SetValue(values, ref val, i);
                    break;
                }
                        
            }
        }
        
    }
}