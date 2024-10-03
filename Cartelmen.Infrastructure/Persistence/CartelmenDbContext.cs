using Cartelmen.Domain.Entities;
using Cartelmen.Infrastructure.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Cartelmen.Infrastructure.Persistence
{
    public class CartelmenDbContext : DbContext
    {
        public DbSet<Worker> Workers { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }
        public DbSet<Building> Buildings { get; set; }

        public DbSet<TimeTrack> TimeTracks { get; set; }

        public CartelmenDbContext(DbContextOptions<CartelmenDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BuildingConfiguration());
            modelBuilder.ApplyConfiguration(new WorkerConfiguration());
            modelBuilder.ApplyConfiguration(new TimeTrackConfiguration());
        }
    }
}