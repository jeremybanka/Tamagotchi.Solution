using MySql.Data.MySqlClient;
using System;
using System.Reflection;
using System.Collections.Generic;

namespace Tamagotchi.Models
{
  public class Pet
  {
    public string Name { get; set; }
    public string Type { get; set; }
    public int Food { get; set; }
    public int Attn { get; set; }
    public int Rest { get; set; }
    public string Guid { get; }
    public Pet(string name, string type)
    {
      Name = name;
      Type = type;
      Food = 100;
      Attn = 100;
      Rest = 100;
      Guid = System.Guid.NewGuid().ToString();
    }

    public Pet(string name, string type, int food, int attn, int rest, string guid)
    {
      Name = name;
      Type = type;
      Food = food;
      Attn = attn;
      Rest = rest;
      Guid = guid;
    }

    // Utilizes a foreach to iterate over object properties
    public override bool Equals(object otherPet)
    {
      Type petType = typeof(Pet);
      if (!(otherPet is Pet))
      {
        return false;
      }
      else
      {
        Pet other = (Pet)otherPet;
        foreach (PropertyInfo pInfo in petType.GetProperties())
        {
          if (pInfo.CanRead)
          {
            object thisValue = pInfo.GetValue(this, null);
            object otherValue = pInfo.GetValue(other, null);
            if (!object.Equals(thisValue, otherValue)) return false;
          }
        }
        return true;
      }
    }

    public static List<Pet> GetAll() // DONT: myPet.GetAll() DO: Pet.GetAll()
    {
      List<Pet> allPets = new();
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand();
      cmd.CommandText = @"SELECT * FROM pets;";
      MySqlDataReader rdr = cmd.ExecuteReader();
      while (rdr.Read())
      {
        string guid = rdr.GetString(0);
        string name = rdr.GetString(1);
        string type = rdr.GetString(2);
        int food = rdr.GetInt32(3);
        int attn = rdr.GetInt32(4);
        int rest = rdr.GetInt32(5);
        Pet myPet = new(name, type, food, attn, rest, guid);
        allPets.Add(myPet);
      }
      conn.Close();
      if (conn != null) conn.Dispose();
      return allPets;
    }
    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand();
      cmd.CommandText = @"DELETE FROM pets;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null) conn.Dispose();
    }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand();


      cmd.CommandText = @"INSERT INTO pets (name, type, food, attn, rest, guid) VALUES (@Name, @Type, @Food, @Attn, @Rest, @Guid);";
      foreach (PropertyInfo pInfo in typeof(Pet).GetProperties())
      {
        if (pInfo.CanRead)
        {
          MySqlParameter param = new();
          param.ParameterName = $"@{pInfo.Name}";
          param.Value = pInfo.GetValue(this, null);
          cmd.Parameters.Add(param);
        }
      }
      cmd.ExecuteNonQuery();

      conn.Close();
      if (conn != null) conn.Dispose();
    }

    public static Pet Find(int searchId)
    {
      return new Pet("Placeholder", "Cybernetic");
    }

    public static void WasteAway()
    {
      // foreach (Pet pet in _instances)
      // {
      //   pet.Food--;
      //   pet.Attn--;
      //   pet.Rest--;
      // }
    }

    public int IncrementStat(int someStat, int howMuch)
    {
      int newStat = someStat;
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
      Attn = IncrementStat(Attn, 10);
    }

    public void TuckIn()
    {
      Rest = IncrementStat(Rest, 20);
    }

  }
}