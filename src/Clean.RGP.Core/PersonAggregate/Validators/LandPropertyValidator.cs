using Clean.RGP.Core.PersonAggregate.Resources;
using FluentValidation;
using FluentValidation.Validators;

namespace Clean.RGP.Core.PersonAggregate.Validators;
public class LandPropertyValidator : AbstractValidator<LandProperty>
{
  public LandPropertyValidator()
  {
    RuleFor(lp => lp.CadastralMark)
      .Must(ValidationHelpers.Be11Digits)
      .WithMessage(ValidationMessages.CadastralMarkValidationMessage);

    RuleFor(lp => lp.Status)
      .IsInEnum()
      .WithMessage(ValidationMessages.LandPropertyStatusValidationMessage);

    RuleFor(lp => lp.Plots)
      .NotEmpty()
      .WithMessage(ValidationMessages.LandPropertyPlotsNotEmptyValidationMessage);

    When(lp => lp.Plots.Any(), () =>
    {
      RuleForEach(lp => lp.Plots)
        .SetValidator(new PlotValidator());
    });
  }
}
