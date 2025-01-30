namespace Forecaster.ApiService.Configuration
{
    public class DbConfigurationSampleProvider : ConfigurationProvider
    {

        public override void Load()
        {
            base.Load();
            Data = new Dictionary<string, string?>
            {
                { "ConnectionStrings:Forecaster", "Server=localhost" }
            };
        }
    }
}
