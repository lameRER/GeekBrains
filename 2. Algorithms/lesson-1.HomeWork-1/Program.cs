using System;

namespace lesson_1.HomeWork_1
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var testCase1 = new TestCase { Number = 5, Expected = "Простое" };
            var testCase2 = new TestCase { Number = 24, Expected = "Не простое" };
            var testCase3 = new TestCase { Number = 79, Expected = "Простое" };
            var testCase4 = new TestCase { Number = -782, Expected = "" };
            var testCase5 = new TestCase { Number = -155, Expected = "" };

            TestCase.Test(testCase1);
            TestCase.Test(testCase2);
            TestCase.Test(testCase3);
            TestCase.Test(testCase4);
            TestCase.Test(testCase5);
            Console.ReadKey();
        }

        public static string Function(int number)
        {
            var d = 0;
            var i = 2;
            while (i < number)
            {
                if (number % i == 0)
                    d++;
                i++;
            }

            return d == 0 ? "Простое" : "Не простое";
        }
    }

    public class TestCase
    {
        public int Number { get; set; }
        public string Expected { get; set; }

        public static void Test(TestCase test)
        {
            var result = Program.Function(test.Number);
            Console.WriteLine(result == test.Expected ? "Valid test" : "Not valid test");
        }
    }
}