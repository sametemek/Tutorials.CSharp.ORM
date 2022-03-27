namespace Tutorials.CSharp.Orm.EntityFrameworkCore
{
    internal class EntityFrameworkCoreWithTransaction
    {
        internal void Execute()
        {
            using var context = new MyContext();
            SqliteDataAccess.Context = context;


            Console.WriteLine("EntityFrameworkCore Example!");
            Console.WriteLine("Hello, NextInventors!");

            SqliteDataAccess.DeleteAllUsers();

            context.Database.BeginTransaction();
            try
            {
                SqliteDataAccess.AddUser(new User() { FirstName = "Aysu", LastName = "Şevik" });
                SqliteDataAccess.AddUser(new User() { FirstName = "Esra", LastName = "Demir" });
                SqliteDataAccess.AddUser(new User() { FirstName = "Serhat", LastName = "Omaç" });
                SqliteDataAccess.AddUser(new User() { FirstName = "Fatih", LastName = "Akgöz" });
                SqliteDataAccess.AddUser(new User() { FirstName = "Samet", LastName = "Emek" });
                //throw new Exception();
                context.Database.CommitTransaction();
            }
            catch (Exception e)
            {
                context.Database.RollbackTransaction();
            }


            var users = SqliteDataAccess.GetUsers();

            foreach (var user in users)
            {
                Console.WriteLine($"{user.FirstName} | {user.LastName}");
            }
        }
    }
}