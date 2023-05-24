using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingOveriding
{
    internal class Animal
    {
        public void eat()
        {
            Console.WriteLine("Munch Munch");
        } 
        public void sleep() 
        {
            Console.WriteLine("zzzzzzzzzzzz");
        }

        public virtual void move() 
        { 
            Console.WriteLine("Moves ..........."); 
        }
    }
}
