using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.RGP.UseCases.Contributors.Get;

public record GetContributorQuery(int ContributorId) : IQuery<Result<ContributorDTO>>;
