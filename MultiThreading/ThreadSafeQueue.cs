using System.Collections.Concurrent;
using System.Text;

namespace MultiThreading;

public class ThreadSafeQueue<T>
{
    private Queue<T> queue = new Queue<T>();
    private readonly object queueLock = new object();

    public ThreadSafeQueue()
    {
        queue = new Queue<T>();
    }

    public void Push(T item)
    {
        lock (queueLock)
        {
            queue.Enqueue(item);
        }
        Console.WriteLine($"{item} added to Queue");
    }

    public void Pop()
    {
        lock (queueLock)
        {
            var x = queue.Dequeue();
            Console.WriteLine($"{x} removed from Queue");
        }
        
    }

    public void PrintQueue()
    {
        
    }
}