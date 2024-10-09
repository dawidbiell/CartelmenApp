using Cartelmen.Application.Mappings;
using Cartelmen.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Cartelmen.Application.Extensions;
public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(WorkerProfile));

        services.AddScoped<IWorkerService, WorkerService>();
        services.AddScoped<IBuildingService, BuildingService>();
            
    }

}
