using System;

namespace lesson_3.HomeWork_1
{
    public readonly struct PointStruct : PointBase
    {
        public int X { get; }
        public int Y { get; }

        public PointStruct(int x, int y)
        {
            if (x <= 0) throw new ArgumentOutOfRangeException(nameof(x)); X = x;
            if (y <= 0) throw new ArgumentOutOfRangeException(nameof(y)); Y = y;
        }
    }
}