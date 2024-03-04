using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.RGP.Core.PersonAggregate;
using Clean.RGP.Core.PersonAggregate.Specifications;

namespace Clean.RGP.UseCases.People.List;
public class GetAllPeopleListHandler(IRepository<Person> _repository)
: IQueryHandler<GetAllPeopleListQuery, Result<List<Person>>>
{
  public async Task<Result<List<Person>>> Handle(GetAllPeopleListQuery request, CancellationToken cancellationToken)
  {
    var spec = new PersonWithLandPropertiesListSpecification();
    var result = await _repository.ListAsync(spec, cancellationToken);

    return Result<List<Person>>.Success(result);
  }
}
