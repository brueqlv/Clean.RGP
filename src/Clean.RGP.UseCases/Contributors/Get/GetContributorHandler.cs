using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.RGP.Core.ContributorAggregate;

namespace Clean.RGP.UseCases.Contributors.Get;

/// <summary>
/// Queries don't necessarily need to use repository methods, but they can if it's convenient
/// </summary>
public class GetContributorHandler(IReadRepository<Contributor> _repository)
  : IQueryHandler<GetContributorQuery, Result<ContributorDTO>>
{
  public async Task<Result<ContributorDTO>> Handle(GetContributorQuery request, CancellationToken cancellationToken)
  {
    var entity = await _repository.GetByIdAsync(request.ContributorId, cancellationToken);
    if (entity == null) return Result.NotFound();

    return new ContributorDTO(entity.Id, entity.Name);
  }
}
