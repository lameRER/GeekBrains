using System;
using System.Collections.Generic;

namespace lesson_4.HomeWork.Library
{
    public class TreeNode : IComparable, ITree
    {
        private const int HORIZONTAL_SCALE = 2;
        private int depth;
        public TreeNode Root { get; private set; }
        public int Count { get; private set; }
        public int Value { get; private set; }
        public  TreeNode Left { get; private set; }
        public  TreeNode Right { get; private set; }

        public TreeNode()
        {
            
        }
        public TreeNode(int data)
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
            if (obj is TreeNode item)
            {
                return Value.CompareTo(item);
            }
            else
            {
                throw new Exception("Не совпадение типов");
            }
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
            TreeNode current = Root;

            while (current != null && current.Value != value)
            {
                if (value < current.Value)
                    current = current.Left;
                else
                    current = current.Right;
            }

            if (current == null)
                return;

            TreeNode parent = current.Root;

            if (current.Right == null)
            {
                if (parent.Left == current)
                    parent.Left = current.Left;
                if (parent.Right == current)
                    parent.Right = current.Left;
                return;
            }
            else if (current.Left == null)
            {
                if (parent.Left == current)
                    parent.Left = current.Right;
                if (parent.Right == current)
                    parent.Right = current.Right;
                return;
            }

            var replace = current.Right;
            while (replace.Left != null)
                replace = replace.Left;
            current.Value = replace.Value;
        }

        public TreeNode GetNodeByValue(int value)
        {
            var current = Root;
            while (current != null && value != current.Value)
            {
                current = value.CompareTo(current.Value) == -1 ? current.Left : current.Right;
            }
            return current;
        }
        
        public int GetHeight()
        {
            var queue = new Queue<TreeNode>();
            var items = new List<TreeNode>();
            var result = 0;

            queue.Enqueue(Root);
            while (queue.Count != 0)
            {
                var current = queue.Dequeue();
                items.Add(current);
                var depth = current.depth + 1;
                result = Math.Max(result, depth);

                if (current.Left != null)
                {
                    current.Left.depth = depth;
                    queue.Enqueue(current.Left);
                }

                if (current.Right != null)
                {
                    current.Right.depth = depth;
                    queue.Enqueue(current.Right);
                }
            }
            return result;
        }

        public void PrintTree()
        {
            // Preorder();
            PrintBranch(Root, Console.WindowWidth / 2, Console.CursorTop, GetHeight());
        }

        private void PrintBranch(TreeNode node, int x, int y, int height, int level = 0)
        {
            Console.SetCursorPosition(x, y + level * 4);
            Console.WriteLine("({0})", node.Value);
            var itemWidth = (1 << height - 1);
            if (node.Left != null)
            {
                level++;
                int branchX = x - itemWidth / (1 << level) * HORIZONTAL_SCALE;
                int textWidth = node.Left.Value.ToString().Length + 2;

                // If it does not fit, we will print (..)
                if (branchX < 0)
                {
                    Console.SetCursorPosition(x + textWidth / 2, y + (level - 1) * 4 + 1);
                    Console.WriteLine("|");
                    Console.SetCursorPosition(x, y + (level - 1) * 4 + 2);
                    Console.WriteLine("(..)");
                    return;
                }
                Console.SetCursorPosition(x, y + (level - 1) * 4 + 1);
                Console.WriteLine("/");
                int width = x - branchX - 2;
                Console.SetCursorPosition(branchX + 2 - (width < 1 ? (width * -1 + 1) : 0), y + (level - 1) * 4 + 2);
                Console.WriteLine(width > 1 ? "".PadRight(width, '-') : "/");
                Console.SetCursorPosition(branchX + 1 - (width < 1 ? (width * -1 + 1) : 0), y + (level - 1) * 4 + 3);
                Console.WriteLine("/");
                PrintBranch(node.Left, branchX, y, height, level);
                level--;
            }
            
            if (node.Right != null)
            {
                level++;
                int branchX = x + itemWidth / (1 << level) * HORIZONTAL_SCALE;
                int textWidth = node.Right.Value.ToString().Length + 2;

                // If it does not fit, we will print (..)
                if (branchX + textWidth > Console.WindowWidth)
                {
                    Console.SetCursorPosition(x + textWidth / 2, y + (level - 1) * 4 + 1);
                    Console.WriteLine("|");
                    Console.SetCursorPosition(x, y + (level - 1) * 4 + 2);
                    Console.WriteLine("(..)");
                    return;
                }

                Console.SetCursorPosition(x + textWidth - 1, y + (level - 1) * 4 + 1);
                Console.WriteLine("\\");
                        
                Console.SetCursorPosition(x + textWidth, y + (level - 1) * 4 + 2);
                int width = branchX - x - textWidth;
                Console.WriteLine(width > 1 ? "".PadRight(width, '-') : "\\");

                Console.SetCursorPosition(branchX + (width < 1 ? (width * -1 + 1) : 0), y + (level - 1) * 4 + 3);
                Console.WriteLine("\\");

                PrintBranch(node.Right, branchX, y, height, level);
                level--;
            }
        }

        public IEnumerable<int> Preorder()
        {
            return Root == null ? new List<int>() : Preorder(Root);
        }

        private IEnumerable<int> Preorder(TreeNode node)
        {
            var list = new List<int>();
            if (node != null)
            {
                list.Add(node.Value);
                if (node.Left != null)
                {
                    list.AddRange(Preorder(node.Left));
                }
                
                if(node.Right != null)
                {
                    list.AddRange(Preorder(node.Right));
                }
            }
            return list;
        }

        public void Add(int value)
        {
            var node = new TreeNode(value);
            if (node.Value.CompareTo(Value) == -1)
            {
                if (Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.Add(value);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.Add(value);
                }
            }
        }
    }
}