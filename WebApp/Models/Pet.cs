using System.Collections.Generic;

namespace Tamagotchi.Models
{
  public class Pet
  {
    // public Dictionary<string, int> Stats = new()
    // {
    //   { "Food", 100 },
    //   { "Attention", 100 },
    //   { "Rest", 100 }
    // };
    public string Name { get; set; }
    public string Type { get; set; }
    public int Food { get; set; }
    public int Attention { get; set; }
    public int Rest { get; set; }

    public int Id { get; }
    private static List<Pet> _instances = new() { };
    public Pet(string name, string type)
    {
      Name = name;
      Type = type;
      Food = 100;
      Attention = 100;
      Rest = 100;

      _instances.Add(this);
      Id = _instances.Count;
    }
    public static List<Pet> GetAll() // DONT: myPet.GetAll() DO: Pet.GetAll()
    {
      return _instances;
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Pet Find(int searchId)
    {
      return _instances[searchId - 1];
    }

    public static void WasteAway()
    {
      foreach (Pet pet in _instances)
      {
        pet.Food--;
        pet.Attention--;
        pet.Rest--;
      }
    }

    public int IncrementStat(int aStat, int howMuch)
    {
      int newStat = aStat;
      if (newStat <= 100 - howMuch)
      {
        newStat += howMuch;
      }
      else
      {
        newStat = 100;
      }
      return newStat;
    }

    public void Feed()
    {
      Food = IncrementStat(Food, 5);
    }

    public void PlayWith()
    {
      Attention = IncrementStat(Attention, 10);
    }

    public void TuckIn()
    {
      Rest = IncrementStat(Rest, 20);
    }

  }
}