using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.RGP.Core.Interfaces;
using Clean.RGP.Core.PersonAggregate;

namespace Clean.RGP.UseCases.People.Delete;
public class DeletePersonByIdHandler(IRepository<Person> _repository)
  : ICommandHandler<DeletePersonByIdCommand, Result>
{
  public async Task<Result> Handle(DeletePersonByIdCommand request, CancellationToken cancellationToken)
  {
    var personToDelete = await _repository.GetByIdAsync(request.PersonId, cancellationToken);

    if (personToDelete!= null)
    {
      await _repository.DeleteAsync(personToDelete, cancellationToken);

      return Result.Success();
    }

    return Result.Error();
  }
}
