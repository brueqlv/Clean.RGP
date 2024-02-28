namespace Clean.RGP.Core.Enums;
public class Enums
{
  public enum LandTypeEnum
  {
    [System.ComponentModel.Description("Aramzeme")]
    ArableLand = 1,

    [System.ComponentModel.Description("Augļu dārzs")]
    FruitGarden = 2,

    [System.ComponentModel.Description("Pļava")]
    Meadow = 3,

    [System.ComponentModel.Description("Ganības")]
    Pastures = 4,

    [System.ComponentModel.Description("Mežs")]
    Forest = 5,

    [System.ComponentModel.Description("Krūmājs")]
    Bushes = 6,

    [System.ComponentModel.Description("Purvs")]
    Swamp = 7,

    [System.ComponentModel.Description("Zeme zem ūdeņiem")]
    LandUnderWaters = 8,

    [System.ComponentModel.Description("Zeme zem zivju dīķiem")]
    LandUnderFishPounds = 9,

    [System.ComponentModel.Description("Zeme zem ēkām un pagalmiem")]
    LandUnderBuildingsAndCourtyards = 10,

    [System.ComponentModel.Description("Zeme zem ceļiem")]
    LandUnderRoads = 11,

    [System.ComponentModel.Description("Pārējās zemes")]
    OtherLands = 12,
  }

  public enum PropertyStatusEnum
  {
    [System.ComponentModel.Description("Ir pirkšanas līgums")]
    HasPurchaseAgreement = 1,

    [System.ComponentModel.Description("Apmaksāts")]
    Paid = 2,

    [System.ComponentModel.Description("Reģistrēts zemes grāmatā")]
    Registered = 3,

    [System.ComponentModel.Description("Pārdors")]
    Sold = 4,
  }

  public enum PersonTypeEnum
  {
    [System.ComponentModel.Description("Privātpersona")]
    Natural = 1,

    [System.ComponentModel.Description("Juridiska")]
    Legal = 2,
  }
}
