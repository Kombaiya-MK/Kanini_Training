namespace doctorModelLibrary
{
    public class Doctor
    {
        public int Id { get; set; }
        public string? name  { get; set; }
        public int exp { get; set; }

        public Doctor() { }
        public Doctor(string name, int exp)
        {
            this.name = name;
            this.exp = exp;
        }

        public void GetDoctorsDetails()
        {
            Console.WriteLine("---------------------Enter Doctor Details-----------------");
            Console.Write("Enter doctor name : ");
            name = Console.ReadLine();
            Console.Write("Enter doctor experience : ");
            exp = Convert.ToInt32(Console.ReadLine());
        }

        public override string ToString()
        {
            string message = "";
            message += $"\nDoctor id : {Id}";
            message += $"\nDoctor Name : {name}";
            message += $"\nDoctor Experience : {exp}";
            return message;
        }
    }
}