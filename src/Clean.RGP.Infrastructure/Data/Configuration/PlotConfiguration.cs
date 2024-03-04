using Clean.RGP.Core.PersonAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clean.RGP.Infrastructure.Data.Configuration;
public class PlotConfiguration : IEntityTypeConfiguration<Plot>
{
  public void Configure(EntityTypeBuilder<Plot> builder)
  {
    builder.HasMany(plot => plot.LandTypes)
      .WithOne(landType => landType.Plot)
      .HasForeignKey(landType => landType.PlotId)
      .OnDelete(DeleteBehavior.Cascade);
  }
}
