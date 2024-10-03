using Cartelmen.Infrastructure.Extensions;
using Cartelmen.Infrastructure.Persistence;
using Cartelmen.Infrastructure.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Cartelmen.Server
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddInfrastructure(builder.Configuration);

            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();


                using var scope = app.Services.CreateScope();

                var dbContext = scope.ServiceProvider.GetRequiredService<CartelmenDbContext>();
                if ((await dbContext.Database.GetPendingMigrationsAsync()).Any())
                {
                    await dbContext.Database.MigrateAsync();
                }

                var dataGenerator = scope.ServiceProvider.GetRequiredService<DataGenerator>();
                await dataGenerator.Seed();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}
