using SynchronizingResourceAccess;
using System.Diagnostics; // To use Stopwatch.
WriteLine("Please wait for the tasks to complete.");

for (int i = 0; i <1 ; i++)
{
    SharedObjects.Message = string.Empty;
    Stopwatch watch = Stopwatch.StartNew();
    Task a = Task.Factory.StartNew(MethodLockA);
    Thread.Sleep(100);
    Task b = Task.Factory.StartNew(MethodLockB);

    Task.WaitAll([a, b]);
    WriteLine();
    WriteLine($"Results: {SharedObjects.Message}.");
    WriteLine($"{watch.ElapsedMilliseconds:N0} elapsed milliseconds.");
}