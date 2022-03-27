using System.Data;
using System.Data.SQLite;
using Dapper;

namespace Tutorials.CSharp.Orm.Dapper
{
    public static class SqliteDataAccess
    {
        public static List<User> GetUsers()
        {
            using IDbConnection connection = new SQLiteConnection(LoadConnectionString());
            var queryResult = connection.Query<User>("select * from Users", new DynamicParameters());
            return queryResult.ToList();
        }

        public static void AddUser(User user)
        {
            using IDbConnection connection = new SQLiteConnection(LoadConnectionString());
            connection.Execute("INSERT INTO Users(FirstName, LastName) values(@FirstName, @LastName)", user);
        }

        public static void DeleteAllUsers()
        {
            using IDbConnection connection = new SQLiteConnection(LoadConnectionString());
            connection.Execute("DELETE FROM Users");
        }

        private static string LoadConnectionString()
        {
            return "Data Source=./OrmTutorialDB.db";
        }
    }
}