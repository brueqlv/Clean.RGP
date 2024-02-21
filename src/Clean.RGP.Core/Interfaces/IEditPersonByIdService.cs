using Ardalis.Result;
using Clean.RGP.Core.PersonAggregate;

namespace Clean.RGP.Core.Interfaces;
public interface IEditPersonByIdService
{
  Task<Result> EditPersonById(int id, Person updatedPerson);
}
