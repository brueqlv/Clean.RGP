using Ardalis.Specification;

namespace Clean.RGP.Core.PersonAggregate.Specifications;
public class PersonByIdSpec : Specification<Person>
{
  public PersonByIdSpec(int id)
  {
    Query
      .Where(p => p.PersonId == id)
      .Include(p => p.LandProperties)
      .ThenInclude(lp => lp.Plots)
      .ThenInclude((plots => plots.LandTypes));
  }
}
