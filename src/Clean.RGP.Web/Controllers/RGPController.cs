﻿using Clean.RGP.Core.PersonAggregate;
using Clean.RGP.UseCases.Contributors.List;
using Clean.RGP.UseCases.People.Create;
using Clean.RGP.UseCases.People.Delete;
using Clean.RGP.UseCases.People.Get;
using Clean.RGP.UseCases.People.List;
using Clean.RGP.UseCases.People.Update;
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

  public async Task<ActionResult> Details(int id)
  {
    Person person = await _mediator.Send(new GetPersonByIdQuery(id));

    return View(person);
  }

  public ActionResult Create()
  {
    return View();
  }

  [HttpPost]
  [ValidateAntiForgeryToken]
  public async Task<ActionResult> Create(Person model)
  {
    if (!ModelState.IsValid)
    {
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
    if (!ModelState.IsValid)
    {
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
}