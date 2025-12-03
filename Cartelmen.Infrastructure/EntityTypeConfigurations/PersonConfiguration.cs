using Cartelmen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cartelmen.Infrastructure.EntityTypeConfigurations;

public class PersonConfiguration: IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.Property(x => x.Id)
            .HasDefaultValueSql("NEWSEQUENTIALID()");
        
        builder.HasOne(cd => cd.Contact)
            .WithOne(w => w.Worker)
            .HasForeignKey<ContactDetails>(w => w.WorkerId);

        builder.HasMany(w => w.Spots)
            .WithMany(b => b.Persons)
            .UsingEntity<SpotPerson>(
                w => w.HasOne(sp => sp.Spot)
                    .WithMany()
                    .HasForeignKey(bw => bw.SpotId),
                w => w.HasOne(bw => bw.Person)
                    .WithMany()
                    .HasForeignKey(bw => bw.PersonId),
                bw =>
                {
                    bw.Property(e => e.Id).ValueGeneratedOnAdd();            // auto-increment
                    bw.Property(e => e.PayRate).HasColumnType("decimal(18,2)");
                    bw.Property(e => e.AssignmentDate).HasDefaultValueSql("getutcdate()");
                }

            );

        // Soft delete configuration
        builder.HasQueryFilter(w => !w.IsDeleted);

        builder.HasIndex( w => w.IsDeleted)
            .HasFilter($"{nameof(Person.IsDeleted)} = 0");

    }
}