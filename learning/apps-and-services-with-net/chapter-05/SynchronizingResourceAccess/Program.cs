using SynchronizingResourceAccess;
using System.Diagnostics; // To use Stopwatch.
WriteLine("Please wait for the tasks to complete.");

for (int i = 0; i < 3; i++)
{
    SharedObjects.Message = string.Empty;
    Stopwatch watch = Stopwatch.StartNew();
    Task a = Task.Factory.StartNew(MethodLockA);
    Task b = Task.Factory.StartNew(MethodLockB);

    Task.WaitAll([a, b]);
    WriteLine();
    WriteLine($"Results: {SharedObjects.Message}.");
    WriteLine($"{watch.ElapsedMilliseconds:N0} elapsed milliseconds.");
}