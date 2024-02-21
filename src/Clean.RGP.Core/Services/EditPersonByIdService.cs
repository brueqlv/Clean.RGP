using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.RGP.Core.Interfaces;
using Clean.RGP.Core.PersonAggregate;

namespace Clean.RGP.Core.Services;
public class EditPersonByIdService(IRepository<Person> _repository) : IEditPersonByIdService
{
  public async Task<Result> EditPersonById(int id, Person updatedPerson)
  {
    var personToEdit = await _repository.GetByIdAsync(id);
    if (personToEdit == null) return Result.NotFound();

    personToEdit.UpdateFrom(updatedPerson);
    await _repository.SaveChangesAsync();

    return Result.Success();
  }
}
