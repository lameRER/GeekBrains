using System;

namespace lesson_4.HomeWork_1
{
    public sealed class StringsArray : BaseFill<string[]>
    {
        private string[] _arrays;

        protected internal override string[] Arrays
        {
            get => _arrays;
            set => _arrays = value ?? throw new ArgumentNullException(nameof(value));
        }

        protected override int N { get; set; }

        public StringsArray(int n)
        {
            if (n <= 0) throw new ArgumentOutOfRangeException(nameof(n));
            N = n;
            SetSizeArray();
        }

        private protected override void SetSizeArray()
        {
            Arrays = new string[N];
        }

        public override void Fill(int j, string text)
        {
            Arrays[j] = text;
        }
    }
}