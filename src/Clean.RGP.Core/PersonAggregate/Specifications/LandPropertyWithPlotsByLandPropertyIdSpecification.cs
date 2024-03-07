using Ardalis.Specification;

namespace Clean.RGP.Core.PersonAggregate.Specifications;
public class LandPropertyWithPlotsByLandPropertyIdSpecification : Specification<LandProperty>
{
  public LandPropertyWithPlotsByLandPropertyIdSpecification(int id)
  {
    Query
      .Include(p => p.Plots)
      .ThenInclude(plots => plots.LandTypes)
      .Where(p => p.LandPropertyId == id);
  }
}
