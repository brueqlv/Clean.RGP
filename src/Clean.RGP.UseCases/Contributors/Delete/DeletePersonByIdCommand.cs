using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.RGP.UseCases.Contributors.Delete;

public record DeletePersonByIdCommand(int PersonId) : ICommand<Result>;
