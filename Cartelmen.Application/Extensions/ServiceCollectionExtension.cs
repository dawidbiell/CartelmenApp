using System.Text;
using Cartelmen.Application.CQRS.Person.Commands;
using Cartelmen.Application.Mappings;
using Cartelmen.Application.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Cartelmen.Application.Extensions;
public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg => 
            cfg.RegisterServicesFromAssembly(typeof(PersonCreateCommand).Assembly));

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                var tokenKey = configuration["TokenKey"] ??
                               throw new ArgumentNullException($"Token key not exists  - {nameof(AddApplication)}.cs");
                options.TokenValidationParameters = new TokenValidationParameters
                {   
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false,

                };
            });
        
        services.AddScoped<ITestService, TestService>();
        services.AddScoped<ITokenService, TokenService>();
        
        services.AddAutoMapper(typeof(PersonProfile));
        services.AddAutoMapper(typeof(SpotProfile));

        services.AddValidatorsFromAssemblyContaining<PersonCreateCommandValidator>()
            .AddFluentValidationAutoValidation();
    }

}
