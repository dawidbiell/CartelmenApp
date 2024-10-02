using Cartelmen.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cartelmen.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<CartelmenDbContext>(
                option => option.UseSqlServer(configuration.GetConnectionString("CartelmenDB"))
            );
        }

    }
}
