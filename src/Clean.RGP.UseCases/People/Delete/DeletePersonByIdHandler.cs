using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.RGP.Core.PersonAggregate;
using Clean.RGP.Core.PersonAggregate.Specifications;

namespace Clean.RGP.UseCases.People.Delete;
public class DeletePersonByIdHandler(IRepository<Person> _repository)
  : ICommandHandler<DeletePersonByIdCommand, Result>
{
  public async Task<Result> Handle(DeletePersonByIdCommand request, CancellationToken cancellationToken)
  {
    var spec = new PersonByIdSpec(request.PersonId);
    var personToDelete = await _repository.FirstOrDefaultAsync(spec, cancellationToken);

    if (personToDelete!= null)
    {
      await _repository.DeleteAsync(personToDelete, cancellationToken);
      await _repository.SaveChangesAsync(cancellationToken);

      return Result.Success();
    }

    return Result.Error();
  }
}
