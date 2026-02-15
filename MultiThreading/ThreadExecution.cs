namespace MultiThreading;

public static class ThreadExecution
{
    // 1) Using Threads directly to perform an operation
    // 2) Blocks Main Thread
    // 3) Threads created manually, not from a Thread pool
    // 4) OS may spawn 100 theads if run in loop for 100 times
    // 5) Join method makes Main thread wait untill all the threads finish exceution
    public static void ThreadDemoWithJoin()
    {
        var thread1 = new Thread(() =>DoWork("1"));
        thread1.Start();
        
        var thread2 = new Thread(() =>DoWork("2"));
        thread2.Start();
        
        thread1.Join();
        thread2.Join();
        Console.WriteLine("Main thread Exiting"); 
    }
    
    // 1) Here the main thread does not wait for other threads to finish
    // 2) This is even more ineffective and Main thread can cleanup resources used by worker threads
    // 3) Still not spawned from ThreadPool, so not an efficient MultiThreading approach
    public static void ThreadDemoWithoutJoin()
    {
        var thread = new Thread(() =>DoWork("1"));
        thread.Start();
        
        var thread2 = new Thread(() =>DoWork("2"));
        thread2.Start();
        
        Console.WriteLine("Main thread Exiting"); 
    } 
    
    // 1) Same exmaple with a BackGround thread
    // 2) Main differenec is that : Main program exits without waiting for Worker threads
    // 3) In above case, threads were foreground. Main Program waits until worker threads finish
    public static void ThreadDemoJoinUsingBackGrorundThread()
    {
        var thread = new Thread(() =>DoWork("1"));
        thread.IsBackground = true;
        thread.Start();
        
        var thread2 = new Thread(() =>DoWork("2"));
        thread2.IsBackground = true;
        thread2.Start();
        
        Console.WriteLine("Main thread Exiting"); 
    } 
    
    public static void DoWork(string name)
    {
        Console.WriteLine($"Thread {name} started : ");
        Thread.Sleep(10000);
        Console.WriteLine($"Thread {name} Stopped : ");
    }
}