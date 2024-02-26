using Ardalis.SharedKernel;
using Clean.RGP.Core.Interfaces;
using Clean.RGP.Core.PersonAggregate;

namespace Clean.RGP.Core.Services;
public class GetAllPeopleListService(IRepository<Person> _repository) : IGetAllPeopleListService
{
  public async Task<List<Person>> GetAllPeopleList()
  {
    return await _repository.ListAsync();
  }
}
