using Clean.RGP.Core.PersonAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.RGP.Infrastructure.Data.Configuration;
public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
  public void Configure(EntityTypeBuilder<Person> builder)
  {
    builder.HasKey(p => p.PersonId);

    builder.HasMany(p => p.LandProperties)
      .WithOne(lp => lp.Person)
      .HasForeignKey(lp => lp.PersonId)
      .OnDelete(DeleteBehavior.Cascade);
  }
}
