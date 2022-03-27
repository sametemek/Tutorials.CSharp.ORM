// See https://aka.ms/new-console-template for more information

using Tutorials.CSharp.Orm.AdoNet;

Console.WriteLine("Hello, NextInventors!");

SqliteDataAccess.DeletePersons();

SqliteDataAccess.AddPerson(new Person() { FirstName = "Aysu", LastName = "Şevik" });
SqliteDataAccess.AddPerson(new Person() { FirstName = "Esra", LastName = "Demir" });
SqliteDataAccess.AddPerson(new Person() { FirstName = "Serhat", LastName = "Omaç" });
SqliteDataAccess.AddPerson(new Person() { FirstName = "Fatih", LastName = "Akgöz" });
SqliteDataAccess.AddPerson(new Person() { FirstName = "Samet", LastName = "Emek" });


var persons = SqliteDataAccess.GetPersons();

foreach (var person in persons)
{
    Console.WriteLine($"{person.Id} | {person.FirstName} | {person.LastName}");
}