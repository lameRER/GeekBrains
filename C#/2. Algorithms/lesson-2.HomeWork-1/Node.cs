using System;

namespace lesson_2.HomeWork_1
{
    public class Node
    {
        private int _value;

        public int Value
        {
            get => _value;
            private set
            {
                if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
                _value = value;
            }
        }

        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }

        public Node(int value)
        {
            Value = value;
        }
    }
}