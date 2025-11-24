using Microsoft.EntityFrameworkCore;
using Cartelmen.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cartelmen.Infrastructure.EntityTypeConfigurations;

public class SpotConfiguration: IEntityTypeConfiguration<Spot>
{
    public void Configure(EntityTypeBuilder<Spot> builder)
    {
        builder.OwnsOne(x => x.Address);

        // Soft delete configuration
        builder.HasQueryFilter(b => !b.IsDeleted);
        builder.HasIndex( w => w.IsDeleted)
            .HasFilter($"{nameof(Spot.IsDeleted)} = 0");
    }
}