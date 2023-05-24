using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorDALLibrary
{
    public class UnableToDeleteException : Exception
    {
        string message;
        public UnableToDeleteException()
        {
            message = "The doctor is already have an appointment. Unable to delete it";
        }
        public override string Message => message;
    }
}