﻿using System.Runtime.Serialization;

namespace DoctorDALLibrary
{
    [Serializable]
    public class NotAvailableException : Exception
    {
        string message;
        public NotAvailableException()
        {
            message = "The data is not available.Unable to get the data.";
        }
        public override string Message => message;
    }
}