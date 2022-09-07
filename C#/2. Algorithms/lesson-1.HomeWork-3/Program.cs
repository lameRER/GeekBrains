using System;

namespace lesson_1.HomeWork_3
{
    class Program
    {
        public static void Main(string[] args)
        {
            var testCaseRec1 = new TestCase { Number = 5, Expected = 5 };
            var testCaseRec2 = new TestCase { Number = 1, Expected = 1 };
            var testCaseRec3 = new TestCase { Number = 10, Expected = 55 };
            var testCaseRec4 = new TestCase { Number = -10, Expected = 0 };
            var testCaseRec5 = new TestCase { Number = 8, Expected = 0 };

            var testCaseFor1 = new TestCase { Number = 6, Expected = 8 };
            var testCaseFor2 = new TestCase { Number = 2, Expected = 1 };
            var testCaseFor3 = new TestCase { Number = 12, Expected = 30 };
            var testCaseFor4 = new TestCase { Number = -7, Expected = 0 };
            var testCaseFor5 = new TestCase { Number = -10, Expected = 0 };

            TestCase.TestRec(testCaseRec1);
            TestCase.TestRec(testCaseRec2);
            TestCase.TestRec(testCaseRec3);
            TestCase.TestRec(testCaseRec4);
            TestCase.TestRec(testCaseRec5);
            TestCase.TestFor(testCaseFor1);
            TestCase.TestFor(testCaseFor2);
            TestCase.TestFor(testCaseFor3);
            TestCase.TestFor(testCaseFor4);
            TestCase.TestFor(testCaseFor5);
            Console.ReadKey();
        }

        public static int FibRec(int n)
        {
            if (n < 0)
                throw new ArgumentException("n не может быть меньше 0");
            switch (n)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
                default:
                    return FibRec(n - 1) + FibRec(n - 2);
            }
        }

        public static int FibFor(int n)
        {
            switch (n)
            {
                case 0:
                    return 0;
                case 1:
                    return 1;
            }

            var sum = 0;
            var previous1 = 0;
            var previous2 = 1;

            for (var i = 2; i <= n; i++)
            {
                sum = previous1 + previous2;
                previous1 = previous2;
                previous2 = sum;
            }
            return n switch
            {
                0 => 0,
                1 => 1,
                _ => sum
            };
        }
    }
    public class TestCase
    {
        public int Number { get; set; }
        public int Expected { get; set; }

        public static void TestRec(TestCase test)
        {
            try
            {
                var result = Program.FibRec(test.Number);
                Console.WriteLine(result == test.Expected ? "Valid test" : "Not valid test");
            }
            catch (Exception e)
            {
                Console.WriteLine("Not valid test");
            }
        }
        public static void TestFor(TestCase test)
        {
            try
            {
                var result = Program.FibFor(test.Number);
                Console.WriteLine(result == test.Expected ? "Valid test" : "Not valid test");
            }
            catch (Exception e)
            {
                Console.WriteLine("Not valid test");
            }
        }
    }
}