using System.Data;
using System.Data.SQLite;
using Dapper;

namespace Tutorials.CSharp.Orm.Dapper
{
    public static class SqliteDataAccess
    {
        public static List<Person> GetPersons()
        {
            using IDbConnection connection = new SQLiteConnection(LoadConnectionString());
            var queryResult = connection.Query<Person>("select * from Person", new DynamicParameters());
            return queryResult.ToList();
        }

        public static void AddPerson(Person person)
        {
            using IDbConnection connection = new SQLiteConnection(LoadConnectionString());
            connection.Execute("INSERT INTO Person(FirstName, LastName) values(@FirstName, @LastName)", person);
        }

        public static void DeletePersons()
        {
            using IDbConnection connection = new SQLiteConnection(LoadConnectionString());
            connection.Execute("DELETE FROM Person");
        }

        private static string LoadConnectionString()
        {
            return "Data Source=./OrmTutorialDB.db";
        }
    }
}