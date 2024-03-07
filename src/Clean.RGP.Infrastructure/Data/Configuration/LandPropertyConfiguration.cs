using Clean.RGP.Core.PersonAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.RGP.Infrastructure.Data.Configuration;
public class LandPropertyConfiguration : IEntityTypeConfiguration<LandProperty>
{
  public void Configure(EntityTypeBuilder<LandProperty> builder)
  {
    builder.HasMany(lp => lp.Plots)
      .WithOne(plot => plot.LandProperty)
      .HasForeignKey(plot => plot.LandPropertyId)
      .OnDelete(DeleteBehavior.Cascade);
  }
}
