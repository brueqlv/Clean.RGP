namespace Clean.RGP.Core.Enums;
public class Enums
{
  public enum LandTypeEnum
  {
    ArableLand = 1,
    FruitGarden = 2,
    Meadow = 3,
    Pastures = 4,
    Forest = 5,
    Bushes = 6,
    Swamp = 7,
    LandUnderWaters = 8,
    LandUnderFishPounds = 9,
    LandUnderBuildingsAndCourtyards = 10,
    LandUnderRoads = 11,
    OtherLands = 12
  }

  public enum PropertyStatusEnum
  {
    HasPurchaseAgreement = 1,
    Paid = 2,
    Registered = 3,
    Sold = 4
  }

  public enum PersonTypeEnum
  {
    Natural = 1,
    Legal = 2
  }
}
