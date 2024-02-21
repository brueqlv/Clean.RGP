namespace Clean.RGP.Core.PersonAggregate;

public class LandType
{
  public int LandTypeId { get; set; }
  public Enums.Enums.LandTypeEnum Type { get; set; }
  public decimal AreaInHectares { get; set; }
  public int PlotId { get; set; }
  public Plot? Plot { get; set; }
}
