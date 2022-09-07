using ThreadPoolApp;

var messages = Enumerable.Range(1, 1000).Select(i => $"Message-{i}");
using (var customThread = new CustomThreadPool(4))
{
    foreach (var message in messages)
    {
        customThread.Execude(message);
    }

    Console.ReadLine();
}
Console.ReadLine();