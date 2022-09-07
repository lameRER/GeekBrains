using System;

namespace lesson_4.HomeWork.Library.Sort
{
    public class CocktailSort<T> : AlgorithmBase<T> where T: IComparable
    {
        public override void Sort()
        {
            SwopCount = 0;
            var left = 0;
            var right = Items.Count - 1;
            while (left<right)
            {
                var sc = SwopCount;
                for (var i = left; i < right; i++)
                {
                    if (Items[i].CompareTo(Items[i + 1]) != 1) continue;
                    Swop(i, i+1);
                    ComparisonCount++;
                }
                right--;
                if(sc == SwopCount) break;
                for (var i = right; i > left; i--)
                {
                    if (Items[i].CompareTo(Items[i - 1]) != -1) continue;
                    Swop(i, i-1);
                    ComparisonCount++;
                }
                left++;
                if(sc == SwopCount) break;
            }
        }
    }
}