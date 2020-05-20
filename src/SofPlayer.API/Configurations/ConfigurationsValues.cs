using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SofPlayer.API.Configurations
{
    public static class ConfigurationsValues
    {
        public static void AddConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            SoftPlayerURL = configuration.GetSection("SoftPlayerURL")?.Value;            
        }

        public static string SoftPlayerURL { get; private set; }       
    }
}
