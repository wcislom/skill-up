using Forecaster.Infrastructure.Metrics;

namespace Microsoft.Extensions.DependencyInjection;

public static class Extensions
{
    public static void AddCallsMeter(this IServiceCollection services)
    {
        services.AddSingleton<CallsMeter>();
    }
}
