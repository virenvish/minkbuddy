using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minkbuddy.Services.AbstractClass;

namespace Minkbuddy.Services
{
    public static class _Configuration
    {
        public static IServiceCollection AddMinkbuddyServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<DataSyncService, CategorySyncService>();
            return services;
        }
    }
}
