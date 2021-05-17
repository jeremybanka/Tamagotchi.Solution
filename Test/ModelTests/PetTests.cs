using MySql.Data.MySqlClient;
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
      GC.SuppressFinalize(this);
    }
    public PetTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=tamagotchi_test;";
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_ItemList()
    {
      //Arrange
      List<Pet> newList = new();

      //Act
      List<Pet> result = Pet.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void PetCtor_CreatesInstanceOfPet_Pet()
    {
      Pet myPet = new("name", "type");
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
      int attnStat = 99;
      int restStat = 99;

      Pet.WasteAway();

      Assert.AreEqual(foodStat, myDogPet.Food);
      Assert.AreEqual(attnStat, myDogPet.Attn);
      Assert.AreEqual(restStat, myDogPet.Rest);
    }

    [TestMethod]
    public void IncrementStatFood5_AddsFiveTo_FoodOfPetInstance()
    {
      Pet myPet = new("doug", "Dog");
      myPet.Food = 50;

      myPet.Food = myPet.IncrementStat(myPet.Food, 5);

      Assert.AreEqual(55, myPet.Food);
    }

    [TestMethod]
    public void IncrementStatSleep10_AddsTenToRest_AndDoesNotExceed100()
    {
      Pet myPet = new("doug", "Dog");
      myPet.Rest = 98;

      myPet.Rest = myPet.IncrementStat(myPet.Rest, 10);

      Assert.AreEqual(100, myPet.Food);
    }
  }
}