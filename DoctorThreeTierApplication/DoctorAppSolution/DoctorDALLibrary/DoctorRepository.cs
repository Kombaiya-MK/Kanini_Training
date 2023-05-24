using System.Runtime;
using DoctorModelLibrary;
namespace DoctorDALLibrary
{
    public class DoctorRepository : IRepo
    {
        static Doctor[] doctors;
        static int count = 0;

        static DoctorRepository()
        {
            count = 0;
        }

        public DoctorRepository()
        {
            int cnt = 0;
            Console.WriteLine("Enter the number of doctors to be added the clinic..");
            while (! int.TryParse(Console.ReadLine(), out cnt))
            {
                Console.WriteLine("Enter Valid Number..");
            }

            doctors = new Doctor[cnt];
        }
        public Doctor Add(Doctor doctor, out bool status)
        {

            status = false;
            if (count < doctors.Length)
            {
                doctors[count] = doctor;
                count++;
                status = true;
                return doctor;
            }

            for(int i = 0; i < doctors.Length;i++) 
            {
                if (doctors[i] == null)
                {
                    doctors[i] = doctor;
                    status = true;
                    return doctor;
                }
                    
            }
            return null;
        }


        private int FindIndex(int id)
        {
            int idx = -1;
            for (int i = 0; i < doctors.Length; i++)
            {
                if (doctors[i] != null)
                {
                    if (doctors[i].Doc_ID == id)
                    {
                        idx = i;
                        break;
                    }
                }
            }
            return idx;
        }
        public Doctor Delete(int id, out bool status)
        {
            int idx = FindIndex(id);
            status = false;
            if (idx == -1)
            {
                Console.WriteLine("There is no doctor is available in the clinic with this id");
                
            }
            else
            {
                doctors[idx] = null; 
                status = true;
            }
           return doctors[idx]; 

        }

        public Doctor Get(int id)
        {
            int idx = FindIndex(id);
            if(idx > 0)
                return doctors[idx];
            return null;
        }

        public Doctor[] GetAll()
        {
           if (doctors.Length > 0)
                return doctors;
            return null;
        }

        public Doctor Update(Doctor doctor, out bool status)
        {
            int id = doctor.Doc_ID;
            int idx = FindIndex(id);
            status = false;
            if (idx > 0)
            {
                doctors[idx] = doctor; 
                status = true;
            }
            else
            {
                Console.WriteLine("There no doctor with this id is available..");
            }
            return doctor;

        }
    }
}