using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.RGP.Core.PersonAggregate;

namespace Clean.RGP.UseCases.People.Get;

public record GetPropertyWithSortedLandTypesByIdQuery(int LandPropertyId) : IQuery<Result<LandProperty>>;
