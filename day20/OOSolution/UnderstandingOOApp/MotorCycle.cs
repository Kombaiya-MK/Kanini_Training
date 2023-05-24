using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingOOApp
{
    internal class MotorCycle : Cycle
    {
        public MotorCycle()  
        {
            Speed = Speed +  50;
            Console.WriteLine("The updated speed for the motor cycle is " + Speed);
        }
    }
}
