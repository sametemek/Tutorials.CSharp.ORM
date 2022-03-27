using System.Data;
using System.Data.SQLite;

namespace Tutorials.CSharp.Orm.AdoNet
{
    public static class SqliteDataAccess
    {
        public static List<Person> GetPersons()
        {
            using IDbConnection connection = new SQLiteConnection(LoadConnectionString());
            connection.Open();
            var sqLiteCommand = connection.CreateCommand();
            sqLiteCommand.CommandText = "select * from Person";

            var sqLiteDataReader = sqLiteCommand.ExecuteReader();

            var persons = new List<Person>();
            while (sqLiteDataReader.Read())
            {
                var person = new Person();

                person.Id = sqLiteDataReader.GetInt32(0);
                person.FirstName = sqLiteDataReader.GetString(1);
                person.LastName = sqLiteDataReader.GetString(2);
                persons.Add(person);
            }

            connection.Close();
            return persons;
        }

        public static void AddPerson(Person person)
        {
            using IDbConnection connection = new SQLiteConnection(LoadConnectionString());
            connection.Open();
            var sqLiteCommand = connection.CreateCommand();
            sqLiteCommand.CommandText =
                $"INSERT INTO Person(FirstName, LastName) values('{person.FirstName}', '{person.LastName}')";
            sqLiteCommand.ExecuteNonQuery();
            connection.Close();
        }

        public static void DeletePersons()
        {
            using IDbConnection connection = new SQLiteConnection(LoadConnectionString());
            connection.Open();
            var sqLiteCommand = connection.CreateCommand();
            sqLiteCommand.CommandText = "DELETE FROM Person";
            sqLiteCommand.ExecuteNonQuery();
            connection.Close();
        }

        private static string LoadConnectionString()
        {
            return "Data Source=./OrmTutorialDB.db";
        }
    }
}