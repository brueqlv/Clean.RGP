using FluentValidation;

namespace Clean.RGP.Core.PersonAggregate.Validators;
public class PersonValidator : AbstractValidator<Person>
{
  public PersonValidator()
  {
    RuleFor(p => p.PersonType)
      .IsInEnum()
      .WithMessage("Nekorekts personas tips.");

    RuleFor(p => p.LandProperties)
      .NotEmpty()
      .WithMessage("Personai jābūt vismaz vienam zemes īpašumam.");

    When(p => p.LandProperties.Any(), () =>
    {
      RuleForEach(p => p.LandProperties)
        .SetValidator(new LandPropertyValidator());
    });
  }
}
