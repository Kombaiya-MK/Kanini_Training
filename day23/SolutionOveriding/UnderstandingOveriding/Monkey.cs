using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingOveriding
{
    internal class Monkey : Animal
    {
        public override void move()
        {
            //base.move();
            Console.WriteLine("Jumps ....");
        }
    }

    internal class oranguttan : Monkey 
    { 
        public override void move()
        {
            Console.WriteLine("Walk and Jumps");
        }
    }
}
