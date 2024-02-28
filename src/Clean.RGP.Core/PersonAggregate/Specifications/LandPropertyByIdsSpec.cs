using Ardalis.Specification;

namespace Clean.RGP.Core.PersonAggregate.Specifications;
public class LandPropertyByIdSpec : Specification<LandProperty>
{
  public LandPropertyByIdSpec(int id)
  {
    Query
      .Include(p => p.Plots)
      .ThenInclude(plots => plots.LandTypes)
      .Where(p => p.LandPropertyId == id);
  }
}
