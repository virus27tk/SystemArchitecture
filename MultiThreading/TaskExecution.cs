namespace MultiThreading;

public static class TaskExecution
{
    // 1) Using Tasks to perform the same operation
    // 2) Threads are created from Thread Pool
    // 3) If run in a loop for 100 times, each thread from 
    //    Thread pool will be taken for execution
    // 4) Task.Delay will still block the Thread for 2 seconds
    // 5) Task.Run() always create a background Thread (never foreground thread), So if there
    //    is not Wait(), Main thread and program itself will finish
    // 6) But in case of Thread, foreground threads is created. So program does not exit,
    //    even if Main thread finish the execution
    public static void TaskDemoWithWait()
    {
        var task = Task.Run(() =>
        {
            Console.WriteLine("Task Started : ");
            Task.Delay(2000).Wait();
            Console.WriteLine("Task Done");
        });

        task.Wait();
        Console.WriteLine("All done");
    }
    
    // 1) There is no wait. This means that Main thread exits the program 
    //     before even Worker thread (BG Thread to be specific) finishes the execution
    public static void TaskDemoWithoutWait()
    {
        var task = Task.Run(() =>
        {
            Console.WriteLine("Task Started : ");
            Task.Delay(2000).Wait();
            Console.WriteLine("Task Done");
        });
        Console.WriteLine("All done");
    }
    
    // 1) async await is used
    // 2) Functionally same usage as above, but using await instead of task.wait()
    // 3) Thread is not blocked instead returned to Thread Pool
    // 4) Others can use the thread from the pool
    // 5) Once await execution finished, fresh thread from the Thread Pool resumes the execution
    // 6) With this, there is no waste of resources (Thread in this case)
    public static async Task TaskDemoWithAsych()
    {
        var task = Task.Run(async () =>
        {
            Console.WriteLine("Task started");
            await Task.Delay(3000);
            Console.WriteLine("Task Done");
        });

        await task;
    }
    
    // 1) async await with a return value
    public static async Task<string> TaskDemoWithReturn()
    {
        var task = Task.Run(async () => {
            await Task.Delay(3000);
            return "With Return Value";
        });

        var result = await task;
        Console.WriteLine(result);
        
        return result;
    }
}