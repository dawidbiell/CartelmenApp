using Cartelmen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cartelmen.Infrastructure.EntityTypeConfigurations;
public  class TimeTrackerConfiguration : IEntityTypeConfiguration<TimeTracker>
{
    public void Configure(EntityTypeBuilder<TimeTracker> builder)
    {
        builder.HasKey(t => new { t.WorkDate, t.SpotPersonId });

        builder.HasOne(x => x.SpotPerson)
            .WithMany()
            .HasForeignKey(x => x.SpotPersonId);
        
        builder.HasIndex( w => w.IsSubmitted)
            .HasFilter($"{nameof(TimeTracker.IsSubmitted)} = 0");
    }
}
