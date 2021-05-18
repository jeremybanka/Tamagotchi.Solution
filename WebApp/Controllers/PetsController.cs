using Microsoft.AspNetCore.Mvc;
using Tamagotchi.Models;
using System.Collections.Generic;
using System;

namespace Tamagotchi.Controllers
{
  public class PetsController : Controller
  {
    [HttpGet("/pets")]
    public ActionResult Index()
    {
      Pet.WasteAway();
      List<Pet> allPets = Pet.GetAll();
      return View(allPets);
    }

    [HttpGet("/pets/new")]
    public ActionResult New()
    {
      Pet.WasteAway();
      return View();
    }

    [HttpPost("/pets")]
    public ActionResult Create(string name, string type)
    {
      Pet.WasteAway();
      new Pet(name, type);
      return RedirectToAction("Index");
    }

    [HttpPost("/pets/reset")]
    public ActionResult ClearAll()
    {
      Pet.WasteAway();
      Pet.ClearAll();
      return RedirectToAction("Index");
    }

    [HttpGet("/pets/{guid}")]
    public ActionResult Show(string guid)
    {
      Pet.WasteAway();
      try
      {
        Pet foundPet = Pet.Find(guid);
        return View(foundPet);
      }
      catch (Exception)
      {
        return RedirectToAction("Index");
      }
    }

    [HttpPost("/pets/{guid}/play-with")]
    public ActionResult PlayWith(string guid)
    {
      Pet foundPet = Pet.Find(guid);
      foundPet.PlayWith();
      return RedirectToAction("Index");
    }

    [HttpPost("/pets/{guid}/feed")]
    public ActionResult Feed(string guid)
    {
      Pet foundPet = Pet.Find(guid);
      foundPet.Feed();
      return RedirectToAction("Index");
    }

    [HttpPost("/pets/{guid}/tuck-in")]
    public ActionResult TuckIn(string guid)
    {
      Pet foundPet = Pet.Find(guid);
      foundPet.TuckIn();
      return RedirectToAction("Index");
    }
  }
}