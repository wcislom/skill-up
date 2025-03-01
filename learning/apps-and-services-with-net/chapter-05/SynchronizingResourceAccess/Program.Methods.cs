using SynchronizingResourceAccess;

partial class Program
{
    private static void MethodA()
    {
        for (int i = 0; i < 5; i++)
        {
            // Simulate two seconds of work on the current thread.
            Thread.Sleep(Random.Shared.Next(2000));
            // Concatenate the letter "A" to the shared message.
            SharedObjects.Message += "A";
            // Show some activity in the console output.
            Write(".");
        }
    }
    private static void MethodB()
    {
        for (int i = 0; i < 5; i++)
        {
            Thread.Sleep(Random.Shared.Next(2000));
            SharedObjects.Message += "B";
            Write(".");
        }
    }

    private static void MethodLockA()
    {
        lock (SharedObjects.Conch)
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(Random.Shared.Next(2000));
                SharedObjects.Message += "A";
                Write(".");
            }
        }
    }
    private static void MethodLockB()
    {
        bool lockTaken = false;

        try
        {
            Monitor.TryEnter(SharedObjects.Conch, TimeSpan.FromSeconds(5), ref lockTaken);
            if (lockTaken)
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(Random.Shared.Next(2000));
                    SharedObjects.Message += "B";
                    Write(".");
                }
            }
            else
            {
                WriteLine("Method B timed out when entering a monitor on conch.");
            }
        }
        finally
        {
            if(lockTaken)
            {
                Monitor.Exit(SharedObjects.Conch);
            }
        }
    }
}