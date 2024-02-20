using Ardalis.Result;
using Clean.RGP.Core.ContributorAggregate;
using Clean.RGP.Core.Interfaces;
using Ardalis.SharedKernel;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Clean.RGP.Core.Services;

public class DeleteContributorService(IRepository<Contributor> _repository,
  ILogger<DeleteContributorService> _logger) : IDeleteContributorService
{
  public async Task<Result> DeleteContributor(int contributorId)
  {
    _logger.LogInformation("Deleting Contributor {contributorId}", contributorId);
    var aggregateToDelete = await _repository.GetByIdAsync(contributorId);
    if (aggregateToDelete == null) return Result.NotFound();

    await _repository.DeleteAsync(aggregateToDelete);
    return Result.Success();
  }
}
