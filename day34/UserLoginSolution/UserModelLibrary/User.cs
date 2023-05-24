namespace UserModelLibrary
{
    public class User : IComparable<User> , IEquatable<User>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public void AddDetails()
        {
            Console.WriteLine("Enter Id : ");
            Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name : ");
            Name = Console.ReadLine();
            GetPassword();
            int choice;
            Console.WriteLine("Enter type of user : \n1.Admin \n2.User");
            choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
                IsAdmin = true;
            else
                IsAdmin = false;
        }
        private void GetPassword()
        {
            string password = "";
            Console.Write("Enter your password: ");
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                {
                    password += keyInfo.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (keyInfo.Key == ConsoleKey.Backspace && password.Length > 0)
                    {
                        password = password.Substring(0, (password.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            while (keyInfo.Key != ConsoleKey.Enter);
            Console.WriteLine();
            Console.WriteLine("The Password You entered is : " + password);
            Password = password;
        }
        public override string ToString()
        {
            int length = Password.Length;
            string password = "";
            for(int i = 0; i < length;i++)
            {
                if (i == 0 || i == length - 1)
                    password += Password[i];
                else
                    password += "*";
                
            }

            string type = "";
            if (IsAdmin)
                type = "Admin";
            else
                type = "User";
            
            return $"\nID : {Id} \nName : {Name} \nPassword : {password} \nUser Type : {type} \n******************************************************************";
        }

        public int CompareTo(User? other)
        {
            return this.Id.CompareTo(other.Id);
        }

        public bool Equals(User? other)
        {
            return (this.Id == other.Id) && (this.Password.Equals(other.Password));
        }

        
    }
}