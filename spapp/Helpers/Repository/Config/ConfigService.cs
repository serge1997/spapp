namespace spapp.Helpers.Repository.Config
{
    public class ConfigService(IConfiguration configuration) : IConfigService
    {
        private readonly IConfiguration _configuration = configuration;


        public string GetSpappApiBaseUrl()
        {
            return _configuration.GetValue<string>("Api-Spapp:Local:BaseUri")!;
        }
    }
}
