using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doctorModelLibrary
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int Did { get; set; }
        public int Pid { get; set; }
        public int slot { get; set; }
        public double fee { get; set; }

        public void TakeAppointmentDetails()
        {
            Console.Write("Enter Doctor Id : ");
            Did = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Patient Id : ");
            Pid = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Slot (1,2,3): ");
            slot = Convert.ToInt32(Console.ReadLine());
            fee = 200D;
        }

        public override string ToString()
        {
            string message = "";
            message += $"Doctor Id : {Did} \nPatient Id : {Pid} \nSlot : {slot} \nConsultant Fee : {fee}";
            return message;
        }

    }
}