using Clean.RGP.Core.PersonAggregate.Resources;
using FluentValidation;

namespace Clean.RGP.Core.PersonAggregate.Validators;
public class PlotValidator : AbstractValidator<Plot>
{
  public PlotValidator()
  {
    RuleFor(p => p.CadastralMark)
      .Must(ValidationHelpers.Be11Digits)
      .WithMessage(ValidationMessages.CadastralMarkValidationMessage);

    RuleFor(p => p.TotalAreaInHectares)
      .NotEmpty()
      .GreaterThan(0)
      .WithMessage(ValidationMessages.PlotTotalAreaBiggerThanZerroValidationMessage)
      .Must((plot, totalArea) => plot.LandTypes == null || plot.LandTypes.Sum(lt => lt.AreaInHectares) <= totalArea)
      .WithMessage(ValidationMessages.PlotLandTypesAreaSumValidationMessage);

    RuleFor(p => p.DateOfSurvey)
      .Must(ValidationHelpers.BeAValidDate)
      .WithMessage(ValidationMessages.PlotSurveyDateValidationMessage)
      .Must(ValidationHelpers.BeInThePast)
      .WithMessage(ValidationMessages.PlotSurveyDateInPastValidationMessage);

    When(p => p.LandTypes != null && p.LandTypes.Any(), () =>
    {
      RuleForEach(p => p.LandTypes)
        .SetValidator(new LandTypeValidator());
    });
  }
}
