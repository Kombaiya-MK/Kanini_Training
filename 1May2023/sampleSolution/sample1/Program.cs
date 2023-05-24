namespace sample1
{
    internal class Program
    {
        Context Context = new Context();

        void addUsers()
        {
            user user = new user() { name = "Naruto" , age = 21};
            Context.Users.Add(user);
            Context.SaveChanges();
        }
        void ShowUsers()
        {
            var users = Context.Users;
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.ShowUsers();
            program.addUsers();
            Console.WriteLine("_--------------------------");
            program.ShowUsers();
        }
    }
}