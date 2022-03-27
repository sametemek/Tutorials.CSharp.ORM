namespace Tutorials.CSharp.Orm.Dapper
{
    public class Person
    {
        public Person()
        {
        }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}