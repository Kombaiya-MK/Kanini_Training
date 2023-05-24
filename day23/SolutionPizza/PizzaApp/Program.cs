using PizzaModelLibrary;
namespace PizzaApp
{
    internal class Program
    {
        void UnderstandingOperatorOverloading()
        {
            Pizza p1, p2, p3;
            p1 = new Pizza(345, "ABC", 101, 3);
            p2 = new Pizza(450.6f, "BBB", 102, 2);
            p3 = p1 + p2;
            //p3.PrintPizzaDetails();
            //if (p1 == p2) 
            //{
            //    Console.WriteLine("They are equal!!!");
            //}
            //else
            //{
            //    Console.WriteLine("Not Equal!!!");
            //}

            //Indexer Overloading
            p1[0] = "Onion";
            p1[1] = "Olives";
            p1[2] = "Tomato";

            Console.WriteLine($"The index of Tomato is {p1["Tomato"]}");
            Console.ReadKey();
        }
        
        public void UnderstandingErrorHandling()
        {
            Pizza pizza = new Pizza();
            pizza.TakePizzaDetails();
            pizza.PrintPizzaDetails();

        }
        static void Main(string[] args)
        {
            new Program().UnderstandingErrorHandling();
            //int number;
            //Console.WriteLine("Please Enter a number : ");
            //bool result = Int32.TryParse(Console.ReadLine(), out number);
            //if (result) 
            //{
            //    Console.WriteLine($"Success.The number is parsed and the result is {number}");
            //}
            //else { Console.WriteLine("Failed!"); }
            Console.ReadKey();
        }
    }
}