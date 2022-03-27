using System.Data;
using System.Data.SQLite;

namespace Tutorials.CSharp.Orm.AdoNet
{
    public static class SqliteDataAccess
    {
        public static List<User> GetUsers()
        {
            using IDbConnection connection = new SQLiteConnection(LoadConnectionString());
            connection.Open();
            var sqLiteCommand = connection.CreateCommand();
            sqLiteCommand.CommandText = "select * from Users";

            var sqLiteDataReader = sqLiteCommand.ExecuteReader();

            var users = new List<User>();
            while (sqLiteDataReader.Read())
            {
                var user = new User();

                user.Id = sqLiteDataReader.GetInt32(0);
                user.FirstName = sqLiteDataReader.GetString(1);
                user.LastName = sqLiteDataReader.GetString(2);
                users.Add(user);
            }

            connection.Close();
            return users;
        }

        public static void AddUser(User user)
        {
            using IDbConnection connection = new SQLiteConnection(LoadConnectionString());
            connection.Open();
            var sqLiteCommand = connection.CreateCommand();
            sqLiteCommand.CommandText =
                $"INSERT INTO Users(FirstName, LastName) values('{user.FirstName}', '{user.LastName}')";
            sqLiteCommand.ExecuteNonQuery();
            connection.Close();
        }

        public static void DeleteAllUsers()
        {
            using IDbConnection connection = new SQLiteConnection(LoadConnectionString());
            connection.Open();
            var sqLiteCommand = connection.CreateCommand();
            sqLiteCommand.CommandText = "DELETE FROM Users";
            sqLiteCommand.ExecuteNonQuery();
            connection.Close();
        }

        private static string LoadConnectionString()
        {
            return "Data Source=./OrmTutorialDB.db";
        }
    }
}