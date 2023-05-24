using DoctorModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorDALLibrary
{
    public interface IRepo
    {
        Doctor Add(Doctor doctor, out bool status);
        Doctor Get(int id);
        Doctor[] GetAll();
        Doctor Update(Doctor doctor, out bool status);
        Doctor Delete(int id, out bool status);


    }
}
