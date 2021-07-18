using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Minkbuddy.Infrastructure
{
    public static class Configuration
    {
        public static IServiceCollection AddMinkbuddyInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            return services;
        }
    }
}
