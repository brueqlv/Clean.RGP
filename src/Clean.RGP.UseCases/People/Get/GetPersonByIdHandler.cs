using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.RGP.Core.Interfaces;
using Clean.RGP.Core.PersonAggregate;

namespace Clean.RGP.UseCases.People.Get;
public class GetPersonByIdHandler(IGetPersonByIdService _getPersonByIdService)
  : IQueryHandler<GetPersonByIdQuery, Result<Person>>
{
  public async Task<Result<Person>> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
  {
    var person = await _getPersonByIdService.GetPersonById(request.PersonId);

    if (person == null)
    {
      return Result<Person>.NotFound();
    }

    return Result<Person>.Success(person);
  }
}
