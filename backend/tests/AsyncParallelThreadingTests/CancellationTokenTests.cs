using System.Diagnostics;

namespace AsyncParallelThreadingTests
{
    public class CancellationTokenTests
    {
        [Fact]
        public async Task Should_set_canceled_state_when_token_is_cancelled()
        {
            Debug.WriteLine("Thread Id: {0}", Thread.CurrentThread.ManagedThreadId);
            Debug.WriteLine("Threads in Thread Pool {0}", ThreadPool.ThreadCount);
            // arrange
            using var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            var task = Task.Run(() =>
            {
                while (true)
                {
                    token.ThrowIfCancellationRequested();
                }
            }, token);

            // act
            await tokenSource.CancelAsync();

            // assert
            Assert.Equal(TaskStatus.WaitingForActivation, task.Status);
            Thread.Sleep(3000);
            Assert.Equal(TaskStatus.Canceled, task.Status);


        }
    }
}
