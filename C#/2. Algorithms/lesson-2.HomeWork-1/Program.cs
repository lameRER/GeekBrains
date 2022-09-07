using System;

namespace lesson_2.HomeWork_1
{
    internal static class Program
    {
        private static void Main()
        {
            var ran = new Random();
            var bidirectionalList = new BidirectionalList();
            CreateNode(bidirectionalList, ran.Next(2, 20), out var values);
            Console.WriteLine(bidirectionalList.ToString());
            Console.WriteLine($"Find: ({bidirectionalList.FindNode(values[ran.Next(0, values.Length-1)]).Value})");
            RemoveNode(bidirectionalList, ran.Next(0, bidirectionalList.GetCount()) - 1);
            Console.WriteLine(bidirectionalList.ToString());
            Console.ReadLine();
        }

        private static void RemoveNode(ILinkedList bidirectionalList, int next)
        {
            bidirectionalList.RemoveNode(next);
        }

        private static void CreateNode(BidirectionalList bidirectionalList, int next, out int[] values)
        {
            var ran = new Random();
            var array = new int[next];
            for (var i = 0; i < next; i++)
            {
                var value = ran.Next(1, 100);
                bidirectionalList.AddNode(value);
                array[i] = value;
            }

            values = array;
        }
    }
}