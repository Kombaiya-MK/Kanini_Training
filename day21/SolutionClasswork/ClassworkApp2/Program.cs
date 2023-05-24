using System.Security.Cryptography.X509Certificates;

namespace ClassworkApp2
{
    internal class Program
    {
        Store store;
        public Program()
        {
            store = new Store();
        }
        
        public void Manage() 
        {
            store.TakeOrder();
            store.AddPizzas();
        }

        static void Main(string[] args)
        {
            new Program().Manage();
           
        }
    }
}