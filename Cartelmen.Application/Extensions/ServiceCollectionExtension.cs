using Cartelmen.Application.CQRS.Person.Commands;
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
            cfg.RegisterServicesFromAssembly(typeof(PersonCreateCommand).Assembly));
        
        services.AddScoped<ITestService, TestService>();
        services.AddScoped<ITokenService, TokenService>();
        
        services.AddAutoMapper(typeof(PersonProfile));
        services.AddAutoMapper(typeof(SpotProfile));

        services.AddValidatorsFromAssemblyContaining<PersonCreateCommandValidator>()
            .AddFluentValidationAutoValidation();
    }

}
