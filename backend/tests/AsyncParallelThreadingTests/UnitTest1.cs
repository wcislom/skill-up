using System.Diagnostics;

namespace AsyncParallelThreadingTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Debug.WriteLine("Thread Id: {0}", Thread.CurrentThread.ManagedThreadId);
            Debug.WriteLine("Threads in Thread Pool {0}", ThreadPool.ThreadCount);

        }
    }
}
