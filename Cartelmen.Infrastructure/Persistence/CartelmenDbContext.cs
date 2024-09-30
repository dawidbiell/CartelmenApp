using Cartelmen.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cartelmen.Infrastructure.Persistence
{
    public class CartelmenDbContext : DbContext
    {
        public DbSet<Worker> Workers { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }
        public DbSet<Building> Buildings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=CartelmenDb;Trusted_connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>()
                .HasOne<ContactDetails>(w =>w.Contact)
                .WithOne(cd =>cd.Worker)
                .HasForeignKey<ContactDetails>(cd =>cd.WorkerId);

            modelBuilder.Entity<Building>()
                .OwnsOne(b => b.Address);
        }
    }
}