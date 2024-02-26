using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.RGP.Core.Interfaces;

namespace Clean.RGP.UseCases.People.Create;

public class AddNewPersonHandler(IAddNewPersonService _addNewPersonService)
  : ICommandHandler<AddNewPersonCommand, Result>
{
  public async Task<Result> Handle(AddNewPersonCommand request, CancellationToken cancellationToken)
  {
    return await _addNewPersonService.AddNewPerson(request.Person);
  }
}
