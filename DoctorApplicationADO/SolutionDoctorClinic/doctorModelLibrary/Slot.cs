using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctorModelLibrary
{
    public class Slot
    {
        public  int slot { get; set; }
        public DateOnly AppointmentDate { get; set; }

        public double Fee { get; set; } 

    }
}
