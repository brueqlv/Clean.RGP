using FluentValidation;

namespace Clean.RGP.Core.PersonAggregate.Validators;
public class PlotValidator : AbstractValidator<Plot>
{
  public PlotValidator()
  {
    RuleFor(p => p.CadastralMark)
      .Must(ValidationHelpers.Be11Digits)
      .WithMessage("Kadastra numuram jāsastāv no 11 cipariem.");

    RuleFor(p => p.TotalAreaInHectares)
      .NotEmpty()
      .GreaterThan(0)
      .WithMessage("Zemes gabala kopplatībai jābūt lielākai par 0.")
      .Must((plot, totalArea) => plot.LandTypes == null || plot.LandTypes.Sum(lt => lt.AreaInHectares) <= totalArea)
      .WithMessage("Zemes gabala kopplatībai jābūt lielakai par zemes lietojumu platību summu.");

    RuleFor(p => p.DateOfSurvey)
      .Must(ValidationHelpers.BeAValidDate)
      .WithMessage("Uzmērīšanas datumam jābūt validam.")
      .Must(ValidationHelpers.BeInThePast)
      .WithMessage("Uzmērīšanas datums nevar būt nākotnē.");

    When(p => p.LandTypes != null && p.LandTypes.Any(), () =>
    {
      RuleForEach(p => p.LandTypes)
        .SetValidator(new LandTypeValidator());
    });
  }
}
