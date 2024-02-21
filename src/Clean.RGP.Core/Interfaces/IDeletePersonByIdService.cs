using Ardalis.Result;

namespace Clean.RGP.Core.Interfaces;
public interface IDeletePersonByIdService
{
  Task<Result> DeletePersonById(int id);
}
