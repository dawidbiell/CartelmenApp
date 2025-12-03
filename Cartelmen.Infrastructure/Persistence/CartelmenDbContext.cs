using Cartelmen.Domain.Entities;
using Cartelmen.Infrastructure.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Cartelmen.Infrastructure.Persistence
{
    public class CartelmenDbContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }
        public DbSet<Spot> Spot { get; set; }
        
        public DbSet<SpotPerson> SpotPerson { get; set; }

        public DbSet<TimeTracker> TimeTracks { get; set; }

        public CartelmenDbContext(DbContextOptions<CartelmenDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SpotConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new TimeTrackerConfiguration());
        }
    }
}