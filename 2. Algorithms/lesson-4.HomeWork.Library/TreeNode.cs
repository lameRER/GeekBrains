using System;
using System.Collections.Generic;

namespace lesson_4.HomeWork.Library
{
    public class TreeNode : IComparable, ITree
    {
        private const int HorizontalScale = 2;
        private int _depth;
        private TreeNode Root { get; set; }
        private int Count { get; set; }
        public int Value { get; private set; }
        private TreeNode Left { get; set; }
        private TreeNode Right { get; set; }

        public TreeNode()
        {
        }

        private TreeNode(int data)
        {
            Value = data;
        }

        public TreeNode(int data, TreeNode left, TreeNode right)
        {
            Value = data;
            Left = left;
            Right = right;
        }

        public int CompareTo(object obj)
        {
            if (obj is TreeNode item) return Value.CompareTo(item);
            else throw new Exception("Не совпадение типов");
        }

        public TreeNode GetRoot()
        {
            return Root;
        }

        public void AddItem(int value)
        {
            if (Root == null)
            {
                Root = new TreeNode(value);
                Count = 1;
                return;
            }

            Root.Add(value);
            Count++;
        }

        public void RemoveItem(int value)
        {
            var current = Root;
            while (current != null && current.Value != value)
                current = value < current.Value ? current.Left : current.Right;
            if (current == null) return;
            var parent = current.Root;
            if (current.Right == null)
            {
                if (parent.Left == current) parent.Left = current.Left;
                if (parent.Right == current) parent.Right = current.Left;
                return;
            }

            if (current.Left == null)
            {
                if (parent.Left == current) parent.Left = current.Right;
                if (parent.Right == current) parent.Right = current.Right;
                return;
            }

            var replace = current.Right;
            while (replace.Left != null) replace = replace.Left;
            current.Value = replace.Value;
        }

        public TreeNode GetNodeByValue(int value)
        {
            var current = Root;
            while (current != null && value != current.Value)
                current = value.CompareTo(current.Value) == -1 ? current.Left : current.Right;
            return current;
        }

        private int GetHeight()
        {
            var queue = new Queue<TreeNode>();
            var items = new List<TreeNode>();
            var result = 0;
            queue.Enqueue(Root);
            while (queue.Count != 0)
            {
                var current = queue.Dequeue();
                items.Add(current);
                var depth = current._depth + 1;
                result = Math.Max(result, depth);
                if (current.Left != null)
                {
                    current.Left._depth = depth;
                    queue.Enqueue(current.Left);
                }

                if (current.Right == null) continue;
                current.Right._depth = depth;
                queue.Enqueue(current.Right);
            }

            return result;
        }

        public void PrintTree()
        {
            PrintBranch(Root, Console.WindowWidth / 2, Console.CursorTop, GetHeight());
        }

        private static void PrintBranch(TreeNode node, int x, int y, int height, int level = 0)
        {
            while (true)
            {
                Console.SetCursorPosition(x, y + level * 4);
                Console.WriteLine("({0})", node.Value);
                var itemWidth = 1 << (height - 1);
                if (node.Left != null)
                {
                    level++;
                    var branchX = x - itemWidth / (1 << level) * HorizontalScale;
                    Console.SetCursorPosition(x, y + (level - 1) * 4 + 1);
                    Console.WriteLine("/");
                    var width = x - branchX - 2;
                    Console.SetCursorPosition(branchX + 2 - (width < 1 ? width * -1 + 1 : 0), y + (level - 1) * 4 + 2);
                    Console.WriteLine(width > 1 ? "".PadRight(width, '-') : "/");
                    Console.SetCursorPosition(branchX + 1 - (width < 1 ? width * -1 + 1 : 0), y + (level - 1) * 4 + 3);
                    Console.WriteLine("/");
                    PrintBranch(node.Left, branchX, y, height, level);
                    level--;
                }

                if (node.Right == null) return;
                {
                    level++;
                    var branchX = x + itemWidth / (1 << level) * HorizontalScale;
                    var textWidth = node.Right.Value.ToString().Length + 2;
                    Console.SetCursorPosition(x + textWidth - 1, y + (level - 1) * 4 + 1);
                    Console.WriteLine("\\");
                    Console.SetCursorPosition(x + textWidth, y + (level - 1) * 4 + 2);
                    var width = branchX - x - textWidth;
                    Console.WriteLine(width > 1 ? "".PadRight(width, '-') : "\\");
                    Console.SetCursorPosition(branchX + (width < 1 ? width * -1 + 1 : 0), y + (level - 1) * 4 + 3);
                    Console.WriteLine("\\");
                    node = node.Right;
                    x = branchX;
                }
            }
        }

        public IEnumerable<TreeNode> BreadthFirstSearch()
        {
            var result = new List<TreeNode>();
            var queue = new Queue<TreeNode>();
            queue.Enqueue(Root);
            while (queue.Count != 0)
            {
                var current = queue.Dequeue();
                result.Add(current);
                if (current.Left != null) queue.Enqueue(current.Left);
                if (current.Right != null) queue.Enqueue(current.Right);
            }

            return result;
        }

        public IEnumerable<TreeNode> DeepFirstSearch()
        {
            var result = new List<TreeNode>();
            var stack = new Stack<TreeNode>();
            stack.Push(Root);
            while (stack.Count != 0)
            {
                var current = stack.Pop();
                result.Add(current);
                if (current.Right != null) stack.Push(current.Right);
                if (current.Left != null) stack.Push(current.Left);
            }

            return result;
        }

        private void Add(int value)
        {
            var node = new TreeNode(value);
            if (node.Value.CompareTo(Value) == -1)
            {
                if (Left == null) Left = node;
                else Left.Add(value);
            }
            else
            {
                if (Right == null) Right = node;
                else Right.Add(value);
            }
        }
    }
}