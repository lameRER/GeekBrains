using System.Diagnostics;

namespace ThreadPoolApp;

public class CustomThreadPool : IDisposable
{
   private readonly List<Thread> _threads;
   private static readonly AutoResetEvent Event = new(true);
   private static readonly Queue<string> Queue = new();
   private static volatile bool _canWork = true;
   
   public CustomThreadPool(int threadCount)
   {
      _threads = new List<Thread>(threadCount);
      for (int i = 0; i < threadCount; i++)
      {
         var thread = Initialize();
          _threads.Add(thread);
      }
   }

   private Thread Initialize()
   {
      var thread = new Thread(WorkingThread)
      {
         Name = $"Thread_{Environment.CurrentManagedThreadId}",
         IsBackground = true,
         Priority = ThreadPriority.Normal
      };
      thread.Start();
      return thread;
   }

   private static void WorkingThread()
   {
      Debug.WriteLine($"Поток {Environment.CurrentManagedThreadId} запущен");
      try
      {
         while (_canWork)
         {
            Event.WaitOne();
            if (!_canWork) break;
            var timer = Stopwatch.StartNew();
            Debug.WriteLine($"Поток {Environment.CurrentManagedThreadId} выполняется");
            if (Queue.Count > 0)
            {
               Thread.Sleep(1000);
               Queue.Dequeue();
               Event.Set();
            }
            timer.Stop();
            Event.Set();
            Debug.WriteLine($"Поток {Environment.CurrentManagedThreadId} завершился за {timer.ElapsedMilliseconds}");
         }
      }
      catch (Exception e)
      {
         Console.WriteLine(e);
         throw;
      }
   }

   public void Execude(string message)
   {
      Queue.Enqueue(message);
   }

   public void Dispose()
   {
      _canWork = false;

      Event.Set();
      foreach (var thread in _threads.Where(thread => !thread.Join(1000)))
      {
         thread.Interrupt();
      }
      Event.Dispose();
      Console.WriteLine("Пул потоков завершен");
   }
}