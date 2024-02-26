using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.RGP.Core.Interfaces;

namespace Clean.RGP.UseCases.People.Delete;
public class DeletePersonByIdHandler(IDeletePersonByIdService _deletePersonByIdService)
  : ICommandHandler<DeletePersonByIdCommand, Result>
{
  public async Task<Result> Handle(DeletePersonByIdCommand request, CancellationToken cancellationToken)
  {
    return await _deletePersonByIdService.DeletePersonById(request.PersonId);
  }
}
