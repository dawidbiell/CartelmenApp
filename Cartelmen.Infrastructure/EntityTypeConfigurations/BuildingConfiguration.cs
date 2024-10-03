using Microsoft.EntityFrameworkCore;
using Cartelmen.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cartelmen.Infrastructure.EntityTypeConfigurations;

public class BuildingConfiguration: IEntityTypeConfiguration<Building>
{
    public void Configure(EntityTypeBuilder<Building> builder)
    {
        builder.OwnsOne(x => x.Address);
    }
}