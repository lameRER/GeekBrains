using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using lesson_4.HomeWork.Library;

namespace lesson_4.HomeWork_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] values = { 16, 8, 4, 2, 1, 3, 6, 5, 7, 12, 10, 9, 11, 14, 13, 15, 24, 20, 18, 17, 19, 22, 21, 23, 28, 26, 25, 27, 30, 29, 31 };
            var ltree = new TreeNode();
            foreach (var item in values)
            {
                ltree.AddItem(item);
            }
            
            var node = ltree.GetNodeByValue(28);
            if (node != null)
                Console.WriteLine($"\nFound an element with the value {node.Value}");
            
            ltree.PrintTree();
            ltree.RemoveItem(8);
            ltree.RemoveItem(20);
            ltree.RemoveItem(28);
            Console.Clear();
            ltree.PrintTree();
            
            Console.ReadKey();
        }
        
    }
}