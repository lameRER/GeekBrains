using System;

namespace lesson_4.HomeWork.Library.Sort
{
    public class BubbleSort<T>: AlgorithmBase<T> where T : IComparable
    {
        public override void Sort()
        {
            SwopCount = 0;
            var count = Items.Count;
            for (var j = 0; j < count; j++)
            {
                for (var i = 0; i < count-1-j; i++)
                {
                    var a = Items[i];
                    var b = Items[i + 1];
                    if (a.CompareTo(b) != 1) continue;
                    Swop(i,i+1);
                    ComparisonCount++;
                }
            }
        }
    }
}