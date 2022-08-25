using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RaceOrganizing.Races;

namespace RaceOrganizing.Sql
{
    public static class StoreExtensions
    {
        public static IServiceCollection AddStore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<Store>();

            services.AddSingleton<IRaceStore>(sp => sp.GetRequiredService<Store>());

            services.AddOptions<StoreOptions>()
                    .Bind(configuration.GetSection("StoreOptions"))
                    .ValidateDataAnnotations();
               
            return services;
                    
        }
    }
}
