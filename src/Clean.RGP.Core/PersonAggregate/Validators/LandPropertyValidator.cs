using FluentValidation;
using FluentValidation.Validators;

namespace Clean.RGP.Core.PersonAggregate.Validators;
public class LandPropertyValidator : AbstractValidator<LandProperty>
{
  public LandPropertyValidator()
  {
    RuleFor(lp => lp.CadastralMark)
      .Must(ValidationHelpers.Be11Digits)
      .WithMessage("Kadastra numuram jāsastāv no 11 cipariem.");

    RuleFor(lp => lp.Status)
      .IsInEnum()
      .WithMessage("Nekorekts status.");

    RuleFor(lp => lp.Plots)
      .NotEmpty()
      .WithMessage("Zemes īpašumam jabūt vismaz vienam zemes gabalam.");

    When(lp => lp.Plots.Any(), () =>
    {
      RuleForEach(lp => lp.Plots)
        .SetValidator(new PlotValidator());
    });
  }
}
