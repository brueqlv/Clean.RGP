using Ardalis.Result;
using Clean.RGP.Core.PersonAggregate;

namespace Clean.RGP.Core.Interfaces;
public interface IAddNewPersonService
{
  Task<Result> AddNewPerson(Person person);
}
