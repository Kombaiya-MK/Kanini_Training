using doctorModelLibrary;

namespace DoctorDALLibrary
{
    public class DoctorRepository : IRepo<Doctor, int>
    {
        public static IDictionary<int , Doctor> doctors = new Dictionary<int , Doctor>();
        public bool Add(Doctor item)
        {
            int len = doctors.Count;
            doctors.Add(item.Id , item);
            if (doctors.Count > len)
            {
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            bool status = false;
            if(doctors.ContainsKey(id))
            {
                doctors.Remove(id);
                status = true;
            }
            return status;  
        }

        public Doctor Get(int id)
        {
            if (doctors.ContainsKey(id))
            {
                return doctors[id];
            }
            else
                return null;
            
        }

        public Doctor[] GetAll()
        {
            
            return doctors.Values.ToArray();
        }

        public bool Update(Doctor item)
        {
            bool status = false;
            if(doctors.ContainsKey((int)item.Id))
            {
                doctors[item.Id] = item;
                status = true;
            }
            return status;
        }
    }
}