using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.RGP.Core.Interfaces;
using Clean.RGP.Core.PersonAggregate;

namespace Clean.RGP.UseCases.People.Update;
public class EditPersonByIdHandler(IEditPersonByIdService _editPersonByIdService)
: ICommandHandler<EditPersonByIdCommand, Result<Person>>
{
  public async Task<Result<Person>> Handle(EditPersonByIdCommand request, CancellationToken cancellationToken)
  {
    return await _editPersonByIdService.EditPersonById(request.Id, request.Person);
  }
}
