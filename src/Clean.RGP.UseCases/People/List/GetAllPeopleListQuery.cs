using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.RGP.Core.PersonAggregate;

namespace Clean.RGP.UseCases.People.List;

public record GetAllPeopleListQuery : IQuery<Result<List<Person>>>;

