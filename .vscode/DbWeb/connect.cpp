#include <iostream>
#include <pqxx/pqxx>

using namespace std;
using namespace pqxx;

int main()
{
  try
  {
    connection C("dbname=your_database user=your_username password=your_password host=localhost port=5432");
    if (C.is_open())
    {
      cout << "Connected to PostgreSQL!" << endl;
      nontransaction N(C);
      result R(N.exec("SELECT * FROM your_table"));

      for (auto row : R)
      {
        cout << "ID: " << row["id"].as<int>() << ", Name: " << row["name"].c_str() << endl;
      }
      C.disconnect();
    }
    else
    {
      cout << "Failed to connect to PostgreSQL" << endl;
    }
  }
  catch (const std::exception &e)
  {
    cerr << e.what() << std::endl;
  }
  return 0;
}
