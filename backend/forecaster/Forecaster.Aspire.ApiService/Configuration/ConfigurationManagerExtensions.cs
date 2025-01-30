using Forecaster.ApiService.Configuration;

namespace Microsoft.Extensions.Configuration
{
    public static class ConfigurationManagerExtensions
    {
        public static ConfigurationManager AddDbConfigurationSample(this ConfigurationManager configurationManager)
        {
            IConfigurationBuilder configBuilder = configurationManager;
            configBuilder.Add(new DbConfigurationSampleSource());
            return configurationManager;
        }
    }
}
