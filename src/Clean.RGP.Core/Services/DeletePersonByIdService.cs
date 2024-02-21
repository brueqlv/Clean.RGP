using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.RGP.Core.Interfaces;
using Clean.RGP.Core.PersonAggregate;

namespace Clean.RGP.Core.Services;
public class DeletePersonByIdService(IRepository<Person> _repository) : IDeletePersonByIdService
{
  public async Task<Result> DeletePersonById(int id)
  {
    var personToDelete = await _repository.GetByIdAsync(id);
    if (personToDelete == null) return Result.NotFound();

    await _repository.DeleteAsync(personToDelete);
    await _repository.SaveChangesAsync();

    return Result.Success();
  }
}
