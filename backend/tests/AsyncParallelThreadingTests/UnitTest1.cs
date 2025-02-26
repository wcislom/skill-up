using System.Diagnostics;

namespace AsyncParallelThreadingTests
{
    public class UnitTest1
    {
        [Fact]
        public async void Test1()
        {
            Debug.WriteLine("Thread Id: {0}", Thread.CurrentThread.ManagedThreadId);
            Debug.WriteLine("Threads in Thread Pool {0}", ThreadPool.ThreadCount);

            using var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            var task = Task.Run(() =>
            {
                while (true)
                {
                    token.ThrowIfCancellationRequested();
                }
            }, token);
            await Task.Delay(5000);
            tokenSource.Cancel();
            Debug.WriteLine("Task status is {0}", task.Status);
        }
    }
}
