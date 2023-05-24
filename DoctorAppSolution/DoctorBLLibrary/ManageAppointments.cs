using DoctorModelLibrary;
using DoctorDALLibrary;
namespace DoctorBLLibrary
{
    public class ManageAppointments : IBookAppointment
    {
        static ClinicDoctor[] BookedAppointments;
        static int Appointment_count = 0;
        IRepo _repo;


        public ManageAppointments()
        {
            BookedAppointments = new ClinicDoctor[5];
        }

        public ManageAppointments(IRepo repo) : this()
        {
            _repo = repo;
        }
        public bool BookAppointment(Doctor doctor, int slot, out bool BookingStatus)
        {
            BookingStatus = false;
            Console.WriteLine(doctor as ClinicDoctor);
            //slot = Convert.ToInt32(Console.ReadLine());

            if (Appointment_count < BookedAppointments.Length)
            {
                ClinicDoctor doc_obj = new ClinicDoctor(doctor);
                if (doc_obj.SlotStatus[slot - 1] == "Available")
                {
                    doc_obj.SlotStatus[slot - 1] = "Booked";
                    BookedAppointments[Appointment_count] = doc_obj;
                    BookedAppointments[Appointment_count].Doc_name = doctor.Doc_name;
                    BookedAppointments[Appointment_count].Doc_ID = doctor.Doc_ID;
                    BookingStatus = true;
                    Appointment_count++;
                }
                else 
                {
                    Console.WriteLine("The slot is already booked!");
                }
                
            }
            return BookingStatus;
        }

        public Doctor[] ShowDoctors()
        {

            return _repo.GetAll();
        }
        public void ShowAppointments()
        {
            if (BookedAppointments.Length == 0)
            {
                Console.WriteLine("There is no active appointments"); ;
            }
            else
            {
                for (int i = 0; i < BookedAppointments.Length; i++)
                {
                    if (BookedAppointments[i] != null)
                    Console.WriteLine($"\nAppointment : {i + 1} \n{BookedAppointments[i]}");

                }
            }
        }

        public bool CheckAvailability(int id , int slot)
        {
            bool status = true;
            if (BookedAppointments.Length > 0)
            {
                for (int i = 0; i < BookedAppointments.Length; i++)
                {
                    if (BookedAppointments[i] != null)
                    {
                        if (BookedAppointments[i].Doc_ID == id && (BookedAppointments[i].SlotStatus[slot - 1] == "Booked"))
                            status = false;
                    }
                    
                }
            }
            else
            {
                Console.WriteLine("Check Point - CheckAvailability");
            }
            return status;
        }
    }
}