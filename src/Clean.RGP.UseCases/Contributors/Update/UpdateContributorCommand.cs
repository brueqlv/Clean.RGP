using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.RGP.UseCases.Contributors.Update;

public record UpdateContributorCommand(int ContributorId, string NewName) : ICommand<Result<ContributorDTO>>;
