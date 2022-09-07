using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Perfolizer.Horology;

namespace lesson_3.HomeWork_1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkClass>();
        }
    }

    public class BenchmarkClass
    {
        private static float PointDistance(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        private static float PointDistance(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        private static double PointDistanceDouble(PointStruct pointOne, PointStruct pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        private static float PointDistanceWithoutSquareRoot(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }

        [Benchmark]
        public void TestPointDistanceClassFloat()
        {
            var pointOne = new PointClass(10, 20);
            var pointTwo = new PointClass(20, 55);
            PointDistance(pointOne, pointTwo);
        }

        [Benchmark]
        public void TestPointDistanceStructFloat()
        {
            var pointOne = new PointStruct(10, 20);
            var pointTwo = new PointStruct(20, 55);
            PointDistance(pointOne, pointTwo);
        }

        [Benchmark]
        public void TestPointDistanceStructDouble()
        {
            var pointOne = new PointStruct(10, 20);
            var pointTwo = new PointStruct(20, 55);
            PointDistanceDouble(pointOne, pointTwo);
        }

        [Benchmark]
        public void TestPointDistanceStructFloatWithoutSquareRoot()
        {
            var pointOne = new PointStruct(10, 20);
            var pointTwo = new PointStruct(20, 55);
            PointDistanceWithoutSquareRoot(pointOne, pointTwo);
        }
    }
}