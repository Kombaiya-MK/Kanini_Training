using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingOOApp
{
    internal class Cycle
    {
        public int NumberOfWheels { get; set; }
        public float Speed { get; set; }
        public string Make { get; set; }

        public Cycle() { }  
        public Cycle(int numberOfWheels, float speed, string make)
        {
            NumberOfWheels = numberOfWheels;
            Speed = speed;
            Make = make;
        }
        public void Horn()
        {
            Console.WriteLine("Pom Pom ... Orama poda...");
        }
        public void Pedal()
        {
            Speed = Speed + 5;
            Console.WriteLine("Speed after increasing " + Speed);
        }

        public void Brake()
        {
            if (Speed < 0) 
            {
                Console.WriteLine("The Cycle is not running....");
            }
            else
            {
                Speed = Speed - 5;
                Console.WriteLine("Speed after brake " + Speed);
            }
            
        }

        public void Display()
        {
            Console.WriteLine("No of wheels : " + NumberOfWheels + " Speed : " + Speed + " Makers : " + Make);

        }
    }

}
