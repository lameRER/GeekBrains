using Task_4;

Console.WriteLine("Запуск программы");
var lists = new SafeList<int>();
var tasks = new List<Task>();

for (int i = 0; i < 10; i++)
{
    tasks.Add(Task.Run(() =>
    {
        for (int j = 0; j < 100; j++)
        {
            lists.Add(j);
        }
    }));
}
await Task.WhenAll(tasks);
Console.WriteLine("Завершение программы");
Console.ReadLine();


