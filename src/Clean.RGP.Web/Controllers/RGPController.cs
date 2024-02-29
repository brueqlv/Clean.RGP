using Clean.RGP.Core.PersonAggregate;
using Clean.RGP.UseCases.People.Create;
using Clean.RGP.UseCases.People.Delete;
using Clean.RGP.UseCases.People.Get;
using Clean.RGP.UseCases.People.List;
using Clean.RGP.UseCases.People.Update;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.RGP.Web.Controllers;
public class RGPController : Controller
{
  private readonly IMediator _mediator;
  private readonly IValidator<Person> _personValidator;

  public RGPController(IMediator mediator, IValidator<Person> personValidator)
  {
    _mediator = mediator;
    _personValidator = personValidator;
  }

  public async Task<IActionResult> Index()
  {
    var peopleList = await _mediator.Send(new GetAllPeopleListQuery());

    return View(peopleList.Value);
  }

  public async Task<ActionResult> Details(int id)
  {
    var person = await _mediator.Send(new GetPersonByIdQuery(id));

    return View(person.Value);
  }

  public ActionResult Create()
  {
    return View();
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<ActionResult> Create(Person model)
  {
    var validationResult = await _personValidator.ValidateAsync(model);

    if (!validationResult.IsValid)
    {
      foreach (var error in validationResult.Errors)
      {
        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
      }

      return View(model);
    }

    await _mediator.Send(new AddNewPersonCommand(model));

    return RedirectToAction("Index");
  }

  public async Task<IActionResult> Edit(int id)
  {
    Person person = await _mediator.Send(new GetPersonByIdQuery(id));

    return View(person);
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<ActionResult> Edit(int id, Person person)
  {
    var validationResult = await _personValidator.ValidateAsync(person);

    if (!validationResult.IsValid)
    {
      foreach (var error in validationResult.Errors)
      {
        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
      }

      return View(person);
    }

    await _mediator.Send(new EditPersonByIdCommand(id, person));

    return RedirectToAction("Index");
  }

  public async Task<ActionResult> Delete(int id)
  {
    await _mediator.Send(new DeletePersonByIdCommand(id));

    return RedirectToAction("Index");
  }

  public async Task<ActionResult> PropertyList(int id)
  {
    var person = await _mediator.Send(new GetPersonByIdQuery(id));

    return View(person.Value);
  }

  public async Task<IActionResult> PlotList(int propertyId)
  {
    var property = await _mediator.Send(new GetPropertyWithSortedLandTypesByIdQuery(propertyId));

    return View(property.Value);
  }
}
