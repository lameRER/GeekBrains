Console.WriteLine("Старт программы");
var thread = new Thread(DoWork);
thread.Start();
Thread.Sleep(4000);
thread.Interrupt(); //Вызывает исключение в потоке
Console.WriteLine("Завершение программы");
Console.ReadLine();

void DoWork()
{
    while (true)
    {
        Console.WriteLine(DateTime.Now);
        Thread.Sleep(1000); //выброшено исключение ThreadInterruptedException в 14-й строке
    }       
}