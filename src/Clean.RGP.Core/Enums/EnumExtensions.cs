using System.ComponentModel;
using System.Reflection;

namespace Clean.RGP.Core.Enums;
public static class EnumExtensions
{
  public static string GetDescription(this Enum value)
  {
    FieldInfo? field = value.GetType().GetField(value.ToString());

    if (field != null)
    {
      DescriptionAttribute? attribute =
        field.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;

      if (attribute != null)
      {
        return attribute.Description;
      }
    }

    return value.ToString();
  }

  public static IEnumerable<object> GetValuesAndDescriptions<TEnum>() where TEnum : Enum
  {
    return Enum.GetValues(typeof(TEnum)).Cast<Enum>().Select(e => new
    {
      Value = (int)(object)e,
      Text = e.GetType()
        .GetMember(e.ToString())
        .FirstOrDefault()
        ?.GetCustomAttribute<DescriptionAttribute>()
        ?.Description ?? e.ToString()
    });
  }
}
