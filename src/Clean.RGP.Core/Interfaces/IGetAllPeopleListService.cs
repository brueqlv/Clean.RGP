using Clean.RGP.Core.PersonAggregate;

namespace Clean.RGP.Core.Interfaces;
public interface IGetAllPeopleListService
{
  Task<List<Person>> GetAllPeopleList();
}
