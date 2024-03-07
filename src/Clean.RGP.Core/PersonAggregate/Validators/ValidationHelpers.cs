namespace Clean.RGP.Core.PersonAggregate.Validators;

public class ValidationHelpers
{
  public static bool Be11Digits(long value)
  {
    string stringValue = value.ToString();
    return stringValue.Length == 11;
  }

  public static bool BeAValidDate(DateTime date)
  {
    return date != DateTime.MinValue;
  }

  public static bool BeInThePast(DateTime date)
  {
    return date.Date <= DateTime.Now.Date;
  }
}
