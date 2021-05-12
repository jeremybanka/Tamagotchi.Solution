using System.Collections.Generic;

namespace Tamagotchi.Models
{
  public class Pet
  {
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
  }
}

// new Pet("George")

// class Pet {
//   constructor(
//     name = "DefaultName", 
//     desc = "Add a description"
//     ) {
//     this.name = name
//     this.desc = desc
//   }
// }