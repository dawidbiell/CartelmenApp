using Cartelmen.Domain.Interfaces;
using Cartelmen.Infrastructure.Persistence;
using Cartelmen.Infrastructure.Repositories;
using Cartelmen.Infrastructure.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cartelmen.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CartelmenDbContext>(
                option => option.UseSqlServer(configuration.GetConnectionString("CartelmenDB"))
            );

            services.AddScoped<DataGenerator>();

            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<ISpotRepository, SpotRepository>();
            services.AddScoped<ISpotPersonsRepository, SpotPersonsRepository>();
            services.AddScoped<ITimeTrackerRepository, TimeTrackerRepository>();




        }

    }
}
