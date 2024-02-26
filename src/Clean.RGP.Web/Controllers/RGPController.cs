using Clean.RGP.UseCases.Contributors.List;
using Clean.RGP.UseCases.People.List;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.RGP.Web.Controllers;
public class RGPController : Controller
{
  private readonly IMediator _mediator;

  public RGPController(IMediator mediator)
  {
    _mediator = mediator;
  }

  public IActionResult Index()
  {
    var peopleList = _mediator.Send(new GetAllPeopleListQuery());
    return View(peopleList.Result.Value);
  }
}
