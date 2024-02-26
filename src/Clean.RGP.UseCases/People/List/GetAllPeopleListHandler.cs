using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.RGP.Core.ContributorAggregate;
using Clean.RGP.Core.Interfaces;
using Clean.RGP.Core.PersonAggregate;

namespace Clean.RGP.UseCases.People.List;
public class GetAllPeopleListHandler(IRepository<Person> _repository)
: IQueryHandler<GetAllPeopleListQuery, Result<List<Person>>>
{
  public async Task<Result<List<Person>>> Handle(GetAllPeopleListQuery request, CancellationToken cancellationToken)
  {
    var result = await _repository.ListAsync();

    return Result.Success(result);
  }
}
