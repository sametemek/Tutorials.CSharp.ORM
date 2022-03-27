// See https://aka.ms/new-console-template for more information

using Tutorials.CSharp.Orm.Dapper;

Console.WriteLine("Hello, NextInventors!");

SqliteDataAccess.DeletePersons();

SqliteDataAccess.AddPerson(new Person("Aysu", "Şevik"));
SqliteDataAccess.AddPerson(new Person("Esra", "Demir"));
SqliteDataAccess.AddPerson(new Person("Serhat", "Omaç"));
SqliteDataAccess.AddPerson(new Person("Fatih", "Akgöz"));
SqliteDataAccess.AddPerson(new Person("Samet", "Emek"));


var persons = SqliteDataAccess.GetPersons();

foreach (var person in persons)
{
    Console.WriteLine($"{person.Id} | {person.FirstName} | {person.LastName}");
}