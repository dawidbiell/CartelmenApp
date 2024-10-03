using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cartelmen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cartelmen.Infrastructure.EntityTypeConfigurations;

public class WorkerConfiguration: IEntityTypeConfiguration<Worker>
{
    public void Configure(EntityTypeBuilder<Worker> builder)
    {
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

    }
}