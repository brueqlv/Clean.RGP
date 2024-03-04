using Clean.RGP.Core.PersonAggregate.Resources;
using FluentValidation;

namespace Clean.RGP.Core.PersonAggregate.Validators;
public class LandTypeValidator : AbstractValidator<LandType>
{
  public LandTypeValidator()
  {
    RuleFor(lt => lt.Type)
      .IsInEnum().WithMessage(ValidationMessages.LandTypeValidationMessage);

    RuleFor(lt => lt.AreaInHectares)
      .GreaterThan(0)
      .WithMessage(ValidationMessages.LandTypeAreaValidationMessage);
  }
}
