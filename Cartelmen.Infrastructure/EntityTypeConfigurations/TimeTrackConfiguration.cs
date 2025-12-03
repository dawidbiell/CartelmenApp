using Cartelmen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cartelmen.Infrastructure.EntityTypeConfigurations;
public  class TimeTrackConfiguration : IEntityTypeConfiguration<TimeTracker>
{
    public void Configure(EntityTypeBuilder<TimeTracker> builder)
    {
        builder.HasKey(t => new { t.WorkDate, t.SpotPersonId });
    }
}
