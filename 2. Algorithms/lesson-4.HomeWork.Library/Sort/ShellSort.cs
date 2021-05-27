using System;

namespace lesson_4.HomeWork.Library.Sort
{
    public class ShellSort<T>: AlgorithmBase<T> where T : IComparable
    {
        public override void Sort()
        {
            SwopCount = 0;
            var step = Items.Count / 2;
            while (step>0)
            {
                for (var i = step; i < Items.Count; i++)
                {
                    var j = i;
                    while ((j>=step) && Items[j-step].CompareTo(Items[j])==1)
                    {
                        Swop(j-step, j);
                        ComparisonCount++;
                        j -= step;
                    }
                }

                step /= 2;
            }
        }
    }
}