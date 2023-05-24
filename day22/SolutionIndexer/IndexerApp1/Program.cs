using ClassworkApp2;

namespace IndexerApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Store Dominos = new Store();
            Dominos.TakeOrder();
            Dominos.AddPizzas();
            //Dominos[0] = new Pizza();
            //Dominos[0].TakePizzaDetails();
            //Dominos[0].
            Dominos[0][0] = "Capsicum";
            Dominos[0].PrintPizzaDetails(Dominos[0]);
            Store McD = new Store();
            McD.TakeOrder();

           // Console.WriteLine(Dominos[0][0]);
        }
    }
}