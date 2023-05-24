using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorModelLibrary;

namespace DoctorModelLibrary
{
    public class ClinicDoctor : Doctor
    {
        //public string AvailableDaay;
        public bool[] SlotStatus = new bool[3];

        public override string ToString()
        {
            return base.ToString() + $"\n9.00 - 11.00am:{SlotStatus[0]}  \t2.00 - 4.00pm {SlotStatus[0]}  \t8.30 - 10.30pm {SlotStatus[0]}";
        }

        protected override void GetDetails()
        {
            base.GetDetails();
            for(int i = 0; i < SlotStatus.Length; i++)
            {
                SlotStatus[i] = true;
            }
        }


    }
}
