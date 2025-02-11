// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;
using Npgsql;
using System.Text;

class Program
{
  static void Main()
  {
    string connString = "Host=localhost;Username=testUser;Password=drum3284;Database=testDb";

    try
    {
      using (var conn = new NpgsqlConnection(connString))
      {
        conn.Open();
        Console.WriteLine("Connected to PostgreSQL!");

        using (var cmd = new NpgsqlCommand("SELECT daytime, test_no, test_name, value, comment FROM test_table", conn))
        using (var reader = cmd.ExecuteReader())
        {
          while (reader.Read())
          {
            Console.WriteLine($"test_no: {reader["test_no"]}, test_name: {reader["test_name"]}, all:{reader["daytime"]}");
            Console.WriteLine(cmd);
          }
        }
      }
    }
    catch (Exception ex)
    {
      // byte[] bytes = Encoding.Default.GetBytes(ex.Message);
      // byte[] bytes = Encoding.Default.GetBytes("エラーメッセージ");
      // string decode = Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8, bytes));
      // Console.WriteLine($"Error: {decode}");
      Console.WriteLine($"Error: {ex.Message}");
    }
  }
}
