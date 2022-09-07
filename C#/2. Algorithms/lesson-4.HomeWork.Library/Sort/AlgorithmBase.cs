using System;
using System.Collections.Generic;

namespace lesson_4.HomeWork.Library.Sort
{
    public class AlgorithmBase<T> where T: IComparable
    {
        public List<T> Items { get; set; } = new List<T>();
        public int SwopCount { get; protected set; } = 0;
        public int ComparisonCount { get; protected set; } = 0;

        protected void Swop(int positionA, int positionB)
        {
            if (positionA >= Items.Count || positionB >= Items.Count) return;
            var temp = Items[positionA];
            Items[positionA] = Items[positionB];
            Items[positionB] = temp;
            SwopCount++;
        }

        public virtual void Sort()
        {
            SwopCount = 0;
            Items.Sort();
        }
    }
}