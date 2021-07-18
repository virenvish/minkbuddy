using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Minkbuddy.DataAccess
{
    public static class Configuration
    {
        public static IServiceCollection AddMinkbuddyDataAccess(this IServiceCollection services, IConfiguration config)
        {
            return services;
        }
    }
}
