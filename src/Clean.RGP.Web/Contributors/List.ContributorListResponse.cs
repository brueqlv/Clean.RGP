using Clean.RGP.Web.ContributorEndpoints;

namespace Clean.RGP.Web.Endpoints.ContributorEndpoints;

public class ContributorListResponse
{
  public List<ContributorRecord> Contributors { get; set; } = new();
}
