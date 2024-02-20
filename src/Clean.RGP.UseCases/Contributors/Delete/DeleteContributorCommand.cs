using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.RGP.UseCases.Contributors.Delete;

public record DeleteContributorCommand(int ContributorId) : ICommand<Result>;
