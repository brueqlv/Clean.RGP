using Ardalis.SharedKernel;

namespace Clean.RGP.Core.PersonAggregate;
public class Person : EntityBase, IAggregateRoot
{
  public int PersonId { get; set; }
  public string Name { get; set; } = string.Empty;
  public string PersonalCodeOrRegistrationNumber { get; set; } = string.Empty;
  public Enums.Enums.PersonTypeEnum PersonType { get; set; }
  public List<LandProperty> LandProperties { get; set; } = [];

  public void UpdateFrom(Person updatedPerson)
  {
    Name =updatedPerson.Name;
    PersonalCodeOrRegistrationNumber = updatedPerson.PersonalCodeOrRegistrationNumber;
    PersonType = updatedPerson.PersonType;
    LandProperties = updatedPerson.LandProperties;
  }
}
