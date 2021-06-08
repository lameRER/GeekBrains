using System;
using System.Collections.Generic;

namespace lesson_6.HomeWork
{
    public class Vertex
    {
        public Vertex(int number)
        {
            if (number <= 0) throw new ArgumentOutOfRangeException(nameof(number));
            Value = number;
        }

        public int Value { get; }

        public List<Edge> Edges { get; } = new List<Edge>(); 

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}