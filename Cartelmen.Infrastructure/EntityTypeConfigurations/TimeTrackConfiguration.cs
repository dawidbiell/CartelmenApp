using Cartelmen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cartelmen.Infrastructure.EntityTypeConfigurations;
public  class TimeTrackConfiguration : IEntityTypeConfiguration<TimeTrack>
{
    public void Configure(EntityTypeBuilder<TimeTrack> builder)
    {
        builder.HasKey(t => new { t.WorkDate, t.BuildingId, t.WorkerId });
    }
}
