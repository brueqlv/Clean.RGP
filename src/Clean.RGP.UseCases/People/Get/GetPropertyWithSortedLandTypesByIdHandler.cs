using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.RGP.Core.PersonAggregate;
using Clean.RGP.Core.PersonAggregate.Specifications;

namespace Clean.RGP.UseCases.People.Get;

public class GetPropertyWithSortedLandTypesByIdHandler(IRepository<LandProperty> _repository)
  : IQueryHandler<GetPropertyWithSortedLandTypesByIdQuery, Result<LandProperty>>
{
  public async Task<Result<LandProperty>> Handle(GetPropertyWithSortedLandTypesByIdQuery request, CancellationToken cancellationToken)
  {
    var spec = new LandPropertyByIdSpec(request.LandPropertyId);
    var landProperty = await _repository.FirstOrDefaultAsync(spec, cancellationToken);

    if (landProperty != null && landProperty.Plots != null)
    {
      foreach (var plot in landProperty.Plots)
      {
        if (plot.LandTypes != null)
        {
          plot.LandTypes = plot.LandTypes.OrderByDescending(lt => lt.AreaInHectares).ToList();
        }
      }

      return Result<LandProperty>.Success(landProperty);
    }

    return Result<LandProperty>.NotFound();
  }
}
