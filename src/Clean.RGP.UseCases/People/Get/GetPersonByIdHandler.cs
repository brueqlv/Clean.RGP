using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.RGP.Core.PersonAggregate;
using Clean.RGP.Core.PersonAggregate.Specifications;

namespace Clean.RGP.UseCases.People.Get;
public class GetPersonByIdHandler(IRepository<Person> _repository)
  : IQueryHandler<GetPersonByIdQuery, Result<Person>>
{
  public async Task<Result<Person>> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
  {
    var spec = new PersonWithLandPropertiesByPersonIdSpecification(request.PersonId);
    var person = await _repository.FirstOrDefaultAsync(spec, cancellationToken);

    if (person == null)
    {
      return Result<Person>.NotFound();
    }

    return Result<Person>.Success(person);
  }
}
