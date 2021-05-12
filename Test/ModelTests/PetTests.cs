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

    [TestMethod]
    public void WasteAway_ReducesAllStatsOf_AllPets()
    {
      Pet myDogPet = new("Buddy", "Dog");
      int foodStat = 99;
      int attentionStat = 99;
      int restStat = 99;

      Pet.WasteAway();

      Assert.AreEqual(foodStat, myDogPet.Food);
      Assert.AreEqual(attentionStat, myDogPet.Attention);
      Assert.AreEqual(restStat, myDogPet.Rest);
    }

    [TestMethod]
    public void Feed_AddsFiveTo_FoodOfPetInstance()
    {
      Pet myPet = new("doug", "Dog");
      myPet.Food = 50;

      myPet.Feed();

      Assert.AreEqual(55, myPet.Food);
    }

    [TestMethod]
    public void Feed_AddsFiveToPetAndDoesNotExceed100_FoodOfPetInstance()
    {
      Pet myPet = new("doug", "Dog");
      myPet.Food = 98;

      myPet.Feed();

      Assert.AreEqual(100, myPet.Food);
    }
  }
}