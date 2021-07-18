using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Minkbuddy.Business
{
    public static class Configuration
    {
        public static IServiceCollection AddMinkbuddyBusiness(this IServiceCollection services, IConfiguration config)
        {
            return services;
        }
    }
}
