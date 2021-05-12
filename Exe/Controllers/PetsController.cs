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
      Pet myPet = new Pet(name, type);
      return RedirectToAction("Index");
    }

    [HttpPost("/pets/reset")]
    public ActionResult ClearAll()
    {
      Pet.WasteAway();
      Pet.ClearAll();
      return RedirectToAction("Index");
    }

    [HttpGet("/pets/{id}")]
    public ActionResult Show(int id)
    {
      Pet.WasteAway();
      try
      {
        Pet foundPet = Pet.Find(id);
        return View(foundPet);
      }
      catch (Exception)
      {
        return RedirectToAction("Index");
      }
    }

    [HttpPost("/pets/{id}/play-with")]
    public ActionResult PlayWith(int id)
    {
      Pet foundPet = Pet.Find(id);
      foundPet.PlayWith();
      return RedirectToAction("Index");
    }

    [HttpPost("/pets/{id}/feed")]
    public ActionResult Feed(int id)
    {
      Pet foundPet = Pet.Find(id);
      foundPet.Feed();
      return RedirectToAction("Index");
    }


    [HttpPost("/pets/{id}/tuck-in")]
    public ActionResult TuckIn(int id)
    {
      Pet foundPet = Pet.Find(id);
      foundPet.TuckIn();
      return RedirectToAction("Index");
    }
  }
}