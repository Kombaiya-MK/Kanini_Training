using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassworkApp2
{
    internal class Pizza
    {
        public double Price { get; set; }
        public string? Name { get; set; }
        public int Id { get; set; }


        public string[]? Toppings;

        public string this[int index]
        {
            get { return Toppings[index]; }
            set { Toppings[index] = value; }
        }
        /// <summary>
        /// This Constructer takes no parameter and assign the toppings count as 5 in default
        /// </summary>
        public Pizza() 
        {
            Toppings = new string[5];
        }

        /// <summary>
        /// This Constructer takes topping count as parameter
        /// </summary>
        /// <param name="topping_count">No of toppings to be added</param>
        public Pizza(int topping_count)
        {
            Toppings = new string[topping_count];
        }

        /// <summary>
        /// This constructor takes 3 parameters except the toppings count
        /// </summary>
        /// <param name="price">Price of pizza</param>
        /// <param name="name">Name of the Pizza</param>
        /// <param name="id">Id of the pizza</param>
        public Pizza(double price, string? name, int id):this()
        {
            Price = price;
            Name = name;
            Id = id;
        }

        /// <summary>
        /// This constructor takes all four parameters
        /// </summary>
        /// <param name="price"></param>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <param name="topping_count"></param>
        public Pizza(double price, string? name, int id, int topping_count) : this(price, name, id)
        {
            Toppings = new string[topping_count];
        }

        private  void TakeDetails() 
        {
            Console.WriteLine("Please enter the Pizza Name");
            Name = Console.ReadLine();
            Console.WriteLine("Please enter the Pizza Price");
            Price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the number of toppings count : ");
            int Toppings_count = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < Toppings_count && Toppings_count < 5; i++)
            {
                Toppings[i] = Console.ReadLine();
            }
        }
        public void TakePizzaDetails()
        {
            Console.WriteLine("Please enter the Pizza Id");
            Id = Convert.ToInt32(Console.ReadLine());
            TakeDetails();
        }

        public void TakePizzaDetails(int id)
        {
            Id = id;
            TakeDetails();
        }
        public void PrintPizzaDetails(Pizza p1)
        {
            Console.WriteLine("Pizza Details");
            Console.WriteLine($"Pizza Id : {Id}");//Interpollation
            Console.WriteLine($"Pizza name : {Name}");//Interpollation
            Console.WriteLine($"Pizza price : Rs.{Price}");//Interpollation
            int count = 0;
            while (Toppings[count] != null)
            {
                Console.WriteLine($"Topping {count} {Toppings[count]}");
                count++;
            }
        }
    }
}
