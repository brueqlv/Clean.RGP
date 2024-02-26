using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.RGP.Core.PersonAggregate;

namespace Clean.RGP.UseCases.People.Get;

public record GetPersonByIdQuery(int PersonId) : IQuery<Result<Person>>;
