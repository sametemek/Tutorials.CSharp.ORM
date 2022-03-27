namespace Tutorials.CSharp.Orm.EntityFrameworkCore
{
    public static class SqliteDataAccess
    {
        public static MyContext Context;

        public static List<User> GetUsers()
        {
            return Context.Users.ToList();
        }

        public static void AddUser(User user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
        }

        public static void DeleteAllUsers()
        {
            Context.Users.RemoveRange(Context.Users.ToList());
            Context.SaveChanges();
        }
    }
}