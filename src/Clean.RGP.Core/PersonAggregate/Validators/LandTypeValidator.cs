using FluentValidation;

namespace Clean.RGP.Core.PersonAggregate.Validators;
public class LandTypeValidator : AbstractValidator<LandType>
{
  public LandTypeValidator()
  {
    RuleFor(lt => lt.Type)
      .IsInEnum().WithMessage("Nekorekts zemes lietojuma tips.");

    RuleFor(lt => lt.AreaInHectares)
      .GreaterThan(0)
      .WithMessage("Zemes tipa platībai jābūt lielākai par 0.");
  }
}
