using Ardalis.Specification;

namespace Clean.RGP.Core.PersonAggregate.Specifications;
public class PersonListSpec : Specification<Person>
{
  public PersonListSpec()
  {
    Query
      .Include(people => people.LandProperties)
      .ThenInclude(lp => lp.Plots)
      .ThenInclude(plots => plots.LandTypes);
  }
}
