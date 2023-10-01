// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;
using System.Diagnostics;
using consoledeneme.DataAccess;

Console.WriteLine("Hello, World!");


using var context = new SchoolContext();

Stopwatch stopWatch = new();
stopWatch.Start();
var users = context.Users.AsEnumerable()
    .Select(x => new
    {
        x.Id,
        x.Password,
        x.Username
    }).ToList();

if(users.Count > 0) {
    foreach (var item in users)
    {
        Console.WriteLine(item);
    }
}
stopWatch.Stop();
Console.WriteLine(stopWatch.ElapsedMilliseconds); //1412
Stopwatch sw1 = new();
sw1.Start();
var users2 = context.Users.AsQueryable()
    .Select(x => new
    {
        x.Id,
        x.Password,
        x.Username
    }).ToList();

if (users2.Count > 0)
{
    foreach (var item in users2)
    {
        Console.WriteLine(item);
    }
}
sw1.Stop();
Console.WriteLine(sw1.ElapsedMilliseconds); //134


Console.ReadLine();


//using (SqlConnection connection = new SqlConnection("Server = localhost,57000; Database = dev_testdb1; User Id = sa; Password = Str#ng_Passw#rd;"))
//{
//    connection.Open();
//    using (SqlCommand command = new SqlCommand("SELECT TOP (1000) [Id]\n      ,[Username]\n      ,[Password]\n  FROM [dev_testdb1].[dbo].[Users]", connection))
//    {
//        using (SqlDataReader reader = command.ExecuteReader())
//        {
//            while (reader.Read())
//            {
//                for (int i = 0; i < reader.FieldCount; i++)
//                {
//                    Console.WriteLine(reader.GetValue(i));
//                }
//                Console.WriteLine();
//            }
//            Console.ReadLine();
//        }

//    }
//    connection.Close();
//}

//"Server=localhost; Database=dev_testdb1; User Id=sa; Password=Str#ng_Passw#rd"


//  "Server=localhost,57000\\Catalog=dev_testdb1;User=sa;Password=Str#ng_Passw#rd"


