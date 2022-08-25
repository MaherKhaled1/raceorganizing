namespace RaceOrganizing.Races
{
    using Microsoft.Extensions.DependencyInjection;
    public static class RacesExtensions
    {
        public static IServiceCollection AddRaces(this IServiceCollection services)
        {
            services.AddSingleton<IRaceManager, RaceManager>();
            return services;
        }
    }
}
