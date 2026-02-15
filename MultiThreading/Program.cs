using MultiThreading;

public class Program
{
    public static async Task Main(string[] args)
    {
        // var ans = await TaskDemoWithReturn();
        // var ans = await TaskExecution.TaskDemoWithReturn();
        // Console.WriteLine($"Main Method Done : {ans}");

        var queue = new ThreadSafeQueue<string>();
        var thread1 = new Thread(() => DoWork<string>(queue, "ABC", "DEF"));
        var thread2 = new Thread(() => DoWork<string>(queue, "SRU", "JAN"));
        thread1.Start();
        thread2.Start();
        thread1.Join();
        thread2.Join();
        
        var queueInt = new ThreadSafeQueue<int>();
        var thread1Int = new Thread(() => DoWork(queueInt, 1, 3));
        var thread2Int = new Thread(() => DoWork(queueInt, 2, 4));
        thread1Int.Start();
        thread2Int.Start();
        thread1Int.Join();
        thread2Int.Join();
        
    }

    public static void DoWork<T>(ThreadSafeQueue<T> queue, T first, T second)
    {
        queue.Push(first);
        queue.Push(second);
        queue.PrintQueue();
        queue.Pop();
        queue.PrintQueue();
        queue.Pop();
        queue.PrintQueue();
    }
}
