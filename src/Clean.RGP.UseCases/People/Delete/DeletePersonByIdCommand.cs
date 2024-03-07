using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.RGP.UseCases.People.Delete;

public record DeletePersonByIdCommand(int PersonId) : ICommand<Result>;
