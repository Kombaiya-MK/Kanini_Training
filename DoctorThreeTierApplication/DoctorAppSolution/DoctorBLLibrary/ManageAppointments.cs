using DoctorModelLibrary;
using DoctorDALLibrary;
namespace DoctorBLLibrary
{
    public class ManageAppointments : IBookAppointment
    {
        static Doctor[] BookedAppointments;
        static int Appointment_count = 0;
        IRepo _repo;


        public ManageAppointments()
        {
            BookedAppointments = new Doctor[5];
        }

        public ManageAppointments(IRepo repo):this()
        { 
            _repo = repo;
        }
        public bool BookAppointment(Doctor doctor, int slot , out bool BookingStatus)
        {
            BookingStatus = false;
            Console.WriteLine(doctor);
            //slot = Convert.ToInt32(Console.ReadLine());
            if (Appointment_count < BookedAppointments.Length) 
            {
                if ((doctor as ClinicDoctor).SlotStatus[slot - 1])
                {
                    BookedAppointments[Appointment_count] = doctor;
                    ((ClinicDoctor)BookedAppointments[Appointment_count]).SlotStatus[slot - 1] = false;
                    BookingStatus = true;
                    Appointment_count++;
                }
                Console.WriteLine("The slot is already booked!");
            }
            return BookingStatus;
        }

        public Doctor[] ShowDoctors()
        {
            
            return _repo.GetAll();
        }
        public void ShowAppointments()
        {
            if(BookedAppointments.Length > 0)
            {
                Console.WriteLine("There is no active appointments"); ;
            }
            else
            {
                for(int i = 0; i < BookedAppointments.Length; i++)
                {
                    Console.WriteLine($"Appointment : {i+1} \n{BookedAppointments[i]}");

                }
            }
        }
    }
}