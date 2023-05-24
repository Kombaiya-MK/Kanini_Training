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
        public string[] SlotStatus = new string[3] {"Available", "Available", "Available" };
        public int Id { get; set; }
        public string Name { get; set; }
        public ClinicDoctor(Doctor d)
        {
            this.Id = d.Doc_ID;
            this.Name = d.Doc_name;
            this.SlotStatus = SlotStatus;
        }
        
        public override string ToString()
        {
            return base.ToString() + $"\n9.00 - 11.00am:{SlotStatus[0]}  \t2.00 - 4.00pm {SlotStatus[0]}  \t8.30 - 10.30pm {SlotStatus[0]}";
        }

        //protected override void GetDetails()
        //{
        //    base.GetDetails();
        //    for (int i = 0; i < SlotStatus.Length; i++)
        //    {
        //        SlotStatus[i] = true;
        //    }
        //}


    }
}
