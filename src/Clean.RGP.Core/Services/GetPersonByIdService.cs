using Ardalis.SharedKernel;
using Clean.RGP.Core.Interfaces;
using Clean.RGP.Core.PersonAggregate;

namespace Clean.RGP.Core.Services;
public class GetPersonByIdService(IRepository<Person> _repository) : IGetPersonByIdService
{
  public async Task<Person?> GetPersonById(int id)
  {
    return await _repository.GetByIdAsync(id); //Kur jāliek include? Vai viņš automātiski iekļauj savienotas tabulas?
  }
}
