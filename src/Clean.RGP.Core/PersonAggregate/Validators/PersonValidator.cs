using Clean.RGP.Core.PersonAggregate.Resources;
using FluentValidation;

namespace Clean.RGP.Core.PersonAggregate.Validators;
public class PersonValidator : AbstractValidator<Person>
{
  public PersonValidator()
  {
    RuleFor(p => p.PersonType)
      .IsInEnum()
      .WithMessage(ValidationMessages.PersonTypeValidationMessage);

    RuleFor(p => p.LandProperties)
      .NotEmpty()
      .WithMessage(ValidationMessages.PersonLandPropertiesNotEmptyValidationMessage);

    When(p => p.LandProperties.Any(), () =>
    {
      RuleForEach(p => p.LandProperties)
        .SetValidator(new LandPropertyValidator());
    });
  }
}
