using Clean.RGP.Core.PersonAggregate;

namespace Clean.RGP.Core.Interfaces;
public interface IGetPersonByIdService
{
  Task<Person?> GetPersonById(int id);
}
