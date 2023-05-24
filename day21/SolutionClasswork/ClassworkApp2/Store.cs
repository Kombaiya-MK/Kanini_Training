using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassworkApp2
{
    internal class Store
    {
        Pizza[] pizzas;

        public void TakeOrder()
        {
            Console.WriteLine("How many pizzas you want ???");
            int counter = Convert.ToInt32(Console.ReadLine());
            pizzas = new Pizza[counter];
        }

        public void AddPizzas()
        {
            for (int i = 0; i < pizzas.Length; i++)
            {
                pizzas[i] = new Pizza();
                pizzas[i].TakePizzaDetails();

            }

            for (int i = 0; i < pizzas.Length; i++)
            {
                pizzas[i].PrintPizzaDetails(pizzas[i]);

            }



        }

    }
}
