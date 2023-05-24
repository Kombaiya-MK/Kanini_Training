using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingOOApp
{
    internal class Phone
    {
        public string Colour { get; set; }

        public void CallingPhone()
        {
            Console.WriteLine("Your " + Colour +  "phone is ringing");
        }
    }
}
