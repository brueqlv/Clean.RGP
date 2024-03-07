using Ardalis.Specification;

namespace Clean.RGP.Core.PersonAggregate.Specifications;
public class PersonWithLandPropertiesListSpecification : Specification<Person>
{
  public PersonWithLandPropertiesListSpecification()
  {
    Query
      .Include(people => people.LandProperties)
      .ThenInclude(lp => lp.Plots)
      .ThenInclude(plots => plots.LandTypes);
  }
}
