using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.RGP.Core.PersonAggregate;

namespace Clean.RGP.UseCases.People.Update;

public record EditPersonByIdCommand(int Id, Person Person) : ICommand<Result<Person>>;
