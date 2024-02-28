using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.RGP.Core.PersonAggregate;
using Clean.RGP.Core.PersonAggregate.Specifications;

namespace Clean.RGP.UseCases.People.Update;
public class EditPersonByIdHandler(IRepository<Person> _repository)
: ICommandHandler<EditPersonByIdCommand, Result<Person>>
{
  public async Task<Result<Person>> Handle(EditPersonByIdCommand request, CancellationToken cancellationToken)
  {
    var spec = new PersonByIdSpec(request.Id);
    var existingPerson = await _repository.FirstOrDefaultAsync(spec, cancellationToken);

    if (existingPerson != null)
    {
      existingPerson.UpdateFrom(request.Person);
      await _repository.SaveChangesAsync(cancellationToken);

      return Result.Success(existingPerson);
    }

    return Result.NotFound();
  }
}
