using Microsoft.AspNetCore.Mvc;
using Tamagotchi.Models;
using System.Collections.Generic;

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
      Pet foundPet = Pet.Find(id);
      return View(foundPet);
    }
  }
}