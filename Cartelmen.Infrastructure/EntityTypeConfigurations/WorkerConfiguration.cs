using Cartelmen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cartelmen.Infrastructure.EntityTypeConfigurations;

public class WorkerConfiguration: IEntityTypeConfiguration<Worker>
{
    public void Configure(EntityTypeBuilder<Worker> builder)
    {
        builder.HasOne(cd => cd.Contact)
            .WithOne(w => w.Worker)
            .HasForeignKey<ContactDetails>(cd => cd.WorkerId);

        builder.HasMany(w => w.Buildings)
            .WithMany(b => b.Workers)
            .UsingEntity<BuildingWorker>(
                w => w.HasOne(bw => bw.Building)
                    .WithMany()
                    .HasForeignKey(bw => bw.BuildingId),
                w => w.HasOne(bw => bw.Worker)
                    .WithMany()
                    .HasForeignKey(bw => bw.WorkerId),
                bw =>
                {
                    bw.Property(e => e.AssignmentDate).HasDefaultValueSql("getutcdate()");
                }

            );

        // Soft delete configuration
        builder.HasQueryFilter(w => !w.IsDeleted);

        builder.HasIndex( w => w.IsDeleted)
            .HasFilter($"{nameof(Worker.IsDeleted)} = 0");

    }
}