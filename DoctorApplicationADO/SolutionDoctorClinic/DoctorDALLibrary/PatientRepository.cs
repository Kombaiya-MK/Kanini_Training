using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using doctorModelLibrary;

namespace DoctorDALLibrary
{
    public class PatientRepository : IRepo<Patient, int>
    {
        public static IDictionary<int, Patient> patients = new Dictionary<int, Patient>();
        public Patient Get(int id)
        {
            if (patients.ContainsKey(id))
                return patients[id];
            else
                return null;
        }

        public bool Add(Patient item)
        {
            patients[item.pid] = item;
            return true;
        }

        public bool Delete(int id)
        {
            bool status = false;
            if (patients.ContainsKey(id))
            {
                patients.Remove(id);
                status = true;
            }
            return status;
        }

        public bool Update(Patient item)
        {
            bool status = false;
            if(patients.ContainsKey(item.pid))
            {
                patients[item.pid] = item;
                status = true;
            }
            return status;
        }

        public Patient[] GetAll()
        {
            return patients.Values.ToArray();
        }

        
    }
}
