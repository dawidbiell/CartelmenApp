using Cartelmen.Application.DTOs;
using Cartelmen.Application.Mappings;
using Cartelmen.Application.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Cartelmen.Application.Extensions;
public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(WorkerProfile));
        services.AddAutoMapper(typeof(BuildingProfile));

        services.AddScoped<IWorkerService, WorkerService>();
        services.AddScoped<IBuildingService, BuildingService>();

        services.AddValidatorsFromAssemblyContaining<WorkerDto>();

    }

}
