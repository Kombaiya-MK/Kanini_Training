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

        public Pizza this[int index]
        {
            get { return pizzas[index]; }
            set { pizzas[index] = value; }
        }
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
                pizzas[i] = new Pizza(4);
                pizzas[i].TakePizzaDetails(101+i);

            }

            for (int i = 0; i < pizzas.Length; i++)
            {
                pizzas[i].PrintPizzaDetails(pizzas[i]);

            }



        }

    }
}
