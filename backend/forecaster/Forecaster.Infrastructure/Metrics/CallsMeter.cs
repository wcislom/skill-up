using System.Diagnostics.Metrics;

namespace Forecaster.Infrastructure.Metrics
{
    public class CallsMeter
    {
        private readonly Meter _meter;
        private readonly Counter<long> _counter;
        public CallsMeter(IMeterFactory factory)
        {
            _meter = factory.Create(nameof(CallsMeter));
            _counter = _meter.CreateCounter<long>("calls");
        }

        public void Record()
        {
            _counter.Add(1);
        }
    }
}
