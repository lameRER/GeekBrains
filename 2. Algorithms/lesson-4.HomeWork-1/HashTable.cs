using System;
using System.Collections.Generic;

namespace lesson_4.HomeWork_1
{
    public sealed class HashTable : BaseFill<HashSet<string>>
    {
        private HashSet<string> _arrays;
        protected override int N { get; set; }

        protected internal override HashSet<string> Arrays
        {
            get => _arrays;
            set => _arrays = value ?? throw new ArgumentNullException(nameof(value));
        }

        public HashTable(int n)
        {
            if (n <= 0) throw new ArgumentOutOfRangeException(nameof(n));
            N = n;
            SetSizeArray();
        }

        private protected override void SetSizeArray()
        {
            Arrays = new HashSet<string>(N);
        }

        public override void Fill(int j, string text)
        {
            Arrays.Add(text);
        }
    }
}