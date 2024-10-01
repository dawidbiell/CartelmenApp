using Cartelmen.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cartelmen.Infrastructure.Persistence
{
    public class CartelmenDbContext : DbContext
    {
        public DbSet<Worker> Workers { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }
        public DbSet<Building> Buildings { get; set; }

        public CartelmenDbContext(DbContextOptions<CartelmenDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=CartelmenDb;Trusted_connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>(entity =>
            {
                entity.HasMany(w => w.Buildings)
                    .WithMany(b => b.Workers)
                    .UsingEntity<BuildingWorker>(
                        w => w.HasOne(bw =>bw.Building)
                            .WithMany()
                            .HasForeignKey(bw =>bw.BuildingId),
                        w => w.HasOne(bw =>bw.Worker)
                            .WithMany()
                            .HasForeignKey(bw =>bw.WorkerId),
                        bw =>
                        {
                            bw.Property(e => e.AssignmentDate).HasDefaultValueSql("getutcdate()");
                        }

                    );
            });


            modelBuilder.Entity<Building>().OwnsOne(x => x.Address);
     




        }
    }
}