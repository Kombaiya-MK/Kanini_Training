namespace CowBullModelLibrary
{
    public class User
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int age { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"Id : {id} \nName : {Name} \nAge : {age} \nPassword : {Password}";
        }
    }
}