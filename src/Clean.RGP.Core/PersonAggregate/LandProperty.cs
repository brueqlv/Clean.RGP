namespace Clean.RGP.Core.PersonAggregate;

public class LandProperty
{
  public int LandPropertyId { get; set; }
  public string Name { get; set; } = string.Empty;
  public long CadastralMark { get; set; }
  public Enums.Enums.PropertyStatusEnum Status { get; set; }
  public List<Plot> Plots { get; set; } = new List<Plot>();
  public int PersonId { get; set; }
  public Person? Person { get; set; }
}
