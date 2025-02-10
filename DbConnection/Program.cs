// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;
using Npgsql;
using System.Text;

class Program
{
  static void Main()
  {
    string connString = "Host=localhost;Username=testUser;Password=Drum3284;Database=testDb";

    try
    {
      using (var conn = new NpgsqlConnection(connString))
      {
        conn.Open();
        Console.WriteLine("Connected to PostgreSQL!");

        using (var cmd = new NpgsqlCommand("SELECT * FROM test_table", conn))
        using (var reader = cmd.ExecuteReader())
        {
          while (reader.Read())
          {
            Console.WriteLine($"ID: {reader["id"]}, Name: {reader["name"]}");
            Console.WriteLine(cmd);
          }
        }
      }
    }
    catch (Exception ex)
    {
      byte[] bytes = Encoding.Default.GetBytes("エラーメッセージ");
      string decode = Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8, ex.Message));
      Console.WriteLine($"Error: {decode}");
    }
  }
}
