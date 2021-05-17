using MySql.Data.MySqlClient;

namespace Tamagotchi.Models
{
  public class DB
  {
    public static MySqlConnection Connection()
    {
      MySqlConnection conn = new(DBConfiguration.ConnectionString);
      return conn;
    }
  }
}