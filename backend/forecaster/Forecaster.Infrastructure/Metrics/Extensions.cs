using Forecaster.Infrastructure.Metrics;

namespace Microsoft.Extensions.DependencyInjection;

public static class Extensions
{
    public static void AddCallsMeter(this IServiceCollection services)
    {
        services.AddSingleton<CallsMeter>();
        services.AddOpenTelemetry().WithMetrics(b => b.AddMeter(nameof(CallsMeter)));
    }
}
