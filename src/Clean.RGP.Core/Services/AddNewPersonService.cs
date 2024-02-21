using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.RGP.Core.Interfaces;
using Clean.RGP.Core.PersonAggregate;

namespace Clean.RGP.Core.Services;

public class AddNewPersonService(IRepository<Person> _repository) : IAddNewPersonService
{
  public async Task<Result> AddNewPerson(Person person)
  {
    await _repository.AddAsync(person);
    await _repository.SaveChangesAsync();

    return Result.Success();
  }
}
