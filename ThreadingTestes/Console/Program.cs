
// See https://aka.ms/new-console-template for more information

using Main;

internal class Program
{
    private static void Main(string[] args)
    {

    }

    public static void ResultCallback(EOperator eOperator, int increament, int totalValue)
    {
        var count = eOperator == EOperator.SUM ? 0 : totalValue;
        while (true)
        {
            if (eOperator== EOperator.SUM)
                count += increament;
            else
                count -= increament;

            Console.WriteLine($"{eOperator} - {count} / {totalValue}");
            if (count <= 0 || count >= totalValue) break;
            Thread.Sleep(100);

        }
    }

    public static void TestCountService()
    {
        var counter = new CountService(5, 100);

        Thread t = new Thread(() => counter.SumUpTo());

        t.Start();

        Console.WriteLine("Main thread will stop");

        t.Join();

        Console.WriteLine("All threads are stoped");
    }

    public static void TestCallbackService()
    {
        var callback = new NumberCallback(5, 100, EOperator.SUBTRACT, ResultCallback);
        var callback2 = new NumberCallback(5, 100, EOperator.SUM, ResultCallback);

        Thread t = new Thread(new ThreadStart(callback.ThreadProc));
        Thread t2 = new Thread(new ThreadStart(callback2.ThreadProc));

        t.Start();
        t2.Start();

        Console.WriteLine("Main thread will stop");

        t.Join();
        t2.Join();

        Console.WriteLine("All threads are stoped");
    }

    public static void ThreadProcPool(Object stateInfo)
    {
        Console.WriteLine("Proc pool info");
    }

    public static void TestPool()
    {
        ThreadPool.QueueUserWorkItem(ThreadProcPool);

        Console.WriteLine("Main thread does some work, then sleeps.");
        Thread.Sleep(1000);

        Console.WriteLine("Main thread exits.");
    }

}