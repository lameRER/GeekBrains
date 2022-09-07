using System;
using System.Collections.Generic;
using lesson_4.HomeWork.Library;

namespace lesson_5.HomeWork_1
{
    internal class Program
    {
        private static void Main()
        {
            int[] values =
            {
                16, 8, 4, 2, 1, 3, 6, 5, 7, 12, 10, 9, 11, 14, 13, 15, 24, 20, 18, 17, 19, 22, 21, 23, 28, 26, 25,
                27, 30, 29, 31
            };
            var lNode = new TreeNode();
            foreach (var item in values) lNode.AddItem(item);
            lNode.PrintTree();
            OutConsole("BFS: ", lNode.BreadthFirstSearch());
            OutConsole("DFS: ", lNode.DeepFirstSearch());
            Console.ReadKey();
        }

        private static void OutConsole(string text, IEnumerable<TreeNode> firstSearch)
        {
            Console.WriteLine();
            Console.Write(text);
            foreach (var item in firstSearch) Console.Write("{0}, ", item.Value);
            Console.WriteLine();
        }
    }
}