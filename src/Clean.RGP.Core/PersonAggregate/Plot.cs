namespace Clean.RGP.Core.PersonAggregate;

public class Plot
{
  public int PlotId { get; set; }
  public long CadastralMark { get; set; }
  public decimal TotalAreaInHectares { get; set; }
  public DateTime DateOfSurvey { get; set; }
  public List<LandType>? LandTypes { get; set; }
  public int LandPropertyId { get; set; }
  public LandProperty? LandProperty { get; set; }
}
