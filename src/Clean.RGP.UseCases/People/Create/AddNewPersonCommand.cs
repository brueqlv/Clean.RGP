using Ardalis.Result;
using Clean.RGP.Core.PersonAggregate;

namespace Clean.RGP.UseCases.People.Create;

public record AddNewPersonCommand(Person Person) : Ardalis.SharedKernel.ICommand<Result>;
