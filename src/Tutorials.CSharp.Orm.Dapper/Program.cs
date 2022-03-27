using Tutorials.CSharp.Orm.Dapper;

Console.WriteLine("Dapper Example!");
Console.WriteLine("Hello, NextInventors!");

SqliteDataAccess.DeleteAllUsers();

SqliteDataAccess.AddUser(new User() { FirstName = "Aysu", LastName = "Şevik" });
SqliteDataAccess.AddUser(new User() { FirstName = "Esra", LastName = "Demir" });
SqliteDataAccess.AddUser(new User() { FirstName = "Serhat", LastName = "Omaç" });
SqliteDataAccess.AddUser(new User() { FirstName = "Fatih", LastName = "Akgöz" });
SqliteDataAccess.AddUser(new User() { FirstName = "Samet", LastName = "Emek" });


var users = SqliteDataAccess.GetUsers();

foreach (var user in users)
{
    Console.WriteLine($"{user.FirstName} | {user.LastName}");
}