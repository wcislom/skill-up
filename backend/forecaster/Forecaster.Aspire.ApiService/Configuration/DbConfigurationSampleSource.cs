namespace Forecaster.ApiService.Configuration
{
    public class DbConfigurationSampleSource : IConfigurationSource
    {
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new DbConfigurationSampleProvider();
        }
    }
}
