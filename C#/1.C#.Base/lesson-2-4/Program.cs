using System;

namespace lesson_2_4
{
    class Program
    { private static int width = 38;
        private static Random random = new Random();
        static void Main(string[] args)
        {
            var textFront = new[] { $"Кассовый чек № {random.Next(100, 999)}", "ООО Компания", $"ИНН {random.Next(100000000, 999999999)}{random.Next(10, 99)}", $"Дата {DateTime.Now}", "Кассир: Иванов Иван Иванович" };
            var textEnd = new[] { "Система налогообложения ОСНО", $"Фиск.чек № {random.Next(100000, 999999)}", $"Код ККТ {random.Next(100000, 999999)}", $"ФН {random.Next(10000, 99999)}", "ОФД Первый ОФД"};
            var production = new[] {"Молоко", "Хлеб", "Кефир", "Сметана", "Жвачка"};
            //var production = new Dictionary<string, double>(5);
            Console.ForegroundColor = ConsoleColor.Green;
            StartConsole(textFront, production, textEnd);
        }

        private static void StartConsole(string[] textFront, string[] production, string[] textEnd)
        {
            
            Line("-", false);
            for (var i = 0; i <= textFront.Length-1; i++)
            {
                Line(textFront[i], (width-textFront[i].Length)/2);
            }
            Line("*");
            Line("Приход", 0);
            Line("Продажа", 0);
            Line("*");
            Console.WriteLine("");
            var temp = true;
            var sum = 0;
            for (var i = 0; i <= production.Length - 1; i++)
            {
                var price = random.Next(10, 200);
                var count = random.Next(1, 5);
                if (temp)
                {
                    Console.Write("|");
                    Console.WriteLine("{0,-8}{1,8}{2,8}{3,12}{4,3}", "Товар", "Цена", "Кол-во", "Стоимость", "|");
                    temp = false;
                }
                Console.Write("|");
                Console.WriteLine("{0,-8}{1,8}{2,8}{3,12}{4, 3}", $"{production[i]}", $"{(double)price}", $"{count}", $"{price * count}", "|");
                sum += (price * count);
            }
            Line("НДС 18%",0,false);
            Line($"Итого: {sum}", 0);
            Line($"НДС 18% {sum/100*13}", 0);
            Line("*");
            for (var i = 0; i <= textEnd.Length - 1; i++)
            {
                Line(textEnd[i], (width - textEnd[i].Length) / 2);
            }
            Line("-");
            Console.ReadLine();
        }

        private static void Line(string line, bool cw = true)
        {
            if(cw)
                Console.WriteLine("");
            for (var i = 1; i <= width; i++)
            {
                if (i == 1)
                    Console.Write("|");
                Console.Write(line);
                if (i == width)
                    Console.Write("|");
            }
        }
        private static void Line(string line, int position, bool cw = true)
        {
            if (cw)
                Console.WriteLine("");
            for (var i = 0; i <= width-line.Length; i++)
            {
                if (i == 0)
                    Console.Write("|");
                Console.Write(i == position ? line : " ");
                if (i == width-line.Length)
                    Console.Write("|");
            }
        }
    }
}

