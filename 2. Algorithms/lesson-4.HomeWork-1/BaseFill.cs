using System;

namespace lesson_4.HomeWork_1
{
    public abstract class BaseFill<T>
    {
        private T _arrays;
        protected abstract int N { get; set; }

        protected internal virtual T Arrays
        {
            get => _arrays;
            set => _arrays = value ?? throw new ArgumentNullException(nameof(value));
        }

        private protected abstract void SetSizeArray();
        public abstract void Fill(int j, string text);
    }
}