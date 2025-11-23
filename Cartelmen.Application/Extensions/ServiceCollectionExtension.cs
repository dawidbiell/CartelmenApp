using Cartelmen.Application.CQRS.Worker.Commands;
using Cartelmen.Application.Mappings;
using Cartelmen.Application.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cartelmen.Application.Extensions;
public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssembly(typeof(WorkerCreateCommand).Assembly));
        
        services.AddScoped<IBuildingService, BuildingService>();
        
        services.AddAutoMapper(typeof(WorkerProfile));
        services.AddAutoMapper(typeof(BuildingProfile));

        services.AddValidatorsFromAssemblyContaining<WorkerCreateCommandValidator>()
            .AddFluentValidationAutoValidation();
    }

}
