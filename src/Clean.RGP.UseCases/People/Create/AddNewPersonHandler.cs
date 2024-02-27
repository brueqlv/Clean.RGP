using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.RGP.Core.PersonAggregate;

namespace Clean.RGP.UseCases.People.Create;

public class AddNewPersonHandler(IRepository<Person> _repository)
  : ICommandHandler<AddNewPersonCommand, Result<Person>>
{
  public async Task<Result<Person>> Handle(AddNewPersonCommand request, CancellationToken cancellationToken)
  {
    var result = await _repository.AddAsync(request.Person);

    return Result.Success(result);
  }
}
