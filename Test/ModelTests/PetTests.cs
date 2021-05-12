using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Tamagotchi.Models;
using System;

namespace Tamagotchi.Tests
{
  [TestClass]
  public class PetTests : IDisposable
  {
    public void Dispose()
    {
      Pet.ClearAll();
    }

    [TestMethod]
    public void PetCtor_CreatesInstanceOfPet_Pet()
    {
      Pet myPet = new Pet("name", "type");
      Assert.AreEqual(typeof(Pet), myPet.GetType());
    }

    [TestMethod]
    public void GetAll_ReturnsPets_PetsList()
    {
      Pet myDogPet = new("Buddy", "Dog");
      Pet myDragonPet = new("Drogo", "Dragon");
      List<Pet> myList = new() { myDogPet, myDragonPet };

      List<Pet> result = Pet.GetAll();

      CollectionAssert.AreEqual(myList, result);

    }
  }
}