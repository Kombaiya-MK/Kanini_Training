namespace PizzaModelLibrary
{
    public class Pizza
    {
        public override string ToString()
        {
            string message = "";
            message += "Pizza Details";
            message += $"\nPizza Id : {Id}";//Interpollation
            message += $"\nPizza name : {Name}";//Interpollation
            message += $"\nPizza price : Rs.{Price}";//Interpollation
            int count = 0;
            while (toppings[count] != null)
            {
                message += $"\nTopping {count} {toppings[count]}";
                count++;
            }
            return message;
        }
        public string[] toppings;

        public string this[int index]
        {
            get { return toppings[index]; }
            set { toppings[index] = value; }
        }

        public int this[string name]
        {

            get
            {
                for (int i = 0; i < toppings.Length; i++)
                {
                    if (toppings[i] == name)
                        return i;
                }
                return -1;
            }
        }
        /// <summary>
        /// Default constructor that will initialize the topping size to 5
        /// </summary>
        public Pizza()
        {
            toppings = new string[5];
        }
        /// <summary>
        /// Except tpping all the properties have to taken in
        /// </summary>
        /// <param name="toppingCount">This will be the number of toppings you can add</param>
        public Pizza(int toppingCount)
        {
            toppings = new string[toppingCount];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="price">Price of teh pizza in INR</param>
        /// <param name="name">Name of the pizza for order</param>
        /// <param name="id">An Unique ID for the pizza</param>

        public Pizza(double price, string? name, int id) : this()
        {
            Price = price;
            Name = name;
            Id = id;
        }
        /// <summary>
        /// All in one
        /// </summary>
        /// <param name="price"></param>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <param name="toppingCount"></param>
        public Pizza(double price, string? name, int id, int toppingCount) : this(price, name, id)
        {
            toppings = new string[toppingCount];
        }

        public double Price { get; set; }
        public string? Name { get; set; }
        public int Id { get; set; }

        private void TakeDetails()
        {
            Console.WriteLine("Please enter the Pizza Name");
            Name = Console.ReadLine();
            Console.WriteLine("Please enter the Pizza Price");
            double price = 0;
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Enter valid data for price !");
            }
            Price = price;
            Console.WriteLine("How many toppings do you like to add??");
            int toppingsCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the toppings");
            for (int i = 0; i < toppingsCount && i < 5; i++)
            {
                toppings[i] = Console.ReadLine();
            }
        }

        public void TakePizzaDetails()
        {
            Console.WriteLine("Please enter the Pizza Id");
            int id = 0;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Enter valid ID");
            }
            Id = id;
            TakeDetails();
        }

        public void TakePizzaDetails(int id)
        {
            Id = id;
            TakeDetails();
        }

        public void PrintPizzaDetails()
        {
            Console.WriteLine("Pizza Details");
            Console.WriteLine($"Pizza Id : {Id}");//Interpollation
            Console.WriteLine($"Pizza name : {Name}");//Interpollation
            Console.WriteLine($"Pizza price : Rs.{Price}");//Interpollation
            int count = 0;
            while (toppings[count] != null)
            {
                Console.WriteLine($"Topping {count} {toppings[count]}");
                count++;
            }
        }

        public static Pizza operator +(Pizza left, Pizza right)
        {
            Pizza pizza = new Pizza
            {
                Price = left.Price + right.Price,
                Name = left.Name + " " + right.Name,
                Id = left.Id
            };
            return pizza;
        }

        public static bool operator == (Pizza left, Pizza right)
        {
            bool result = false;
            if(left.Price == right.Price && left.Name == right.Name)
                result = true;
            return result;
        }

        public static bool operator != (Pizza left, Pizza right)
        {
            bool result = true;
            if(left.Price == right.Price && left.Name == right.Name)
                result = false;
            return result;
        }




    }
}