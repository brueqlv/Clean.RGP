using Ardalis.Specification;

namespace Clean.RGP.Core.PersonAggregate.Specifications;
public class PersonWithLandPropertiesByPersonIdSpecification : Specification<Person>
{
  public PersonWithLandPropertiesByPersonIdSpecification(int id)
  {
    Query
      .Where(p => p.PersonId == id)
      .Include(p => p.LandProperties)
      .ThenInclude(lp => lp.Plots)
      .ThenInclude((plots => plots.LandTypes));
  }
}
