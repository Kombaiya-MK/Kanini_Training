using System.Runtime.Serialization;

namespace DoctorBLLibrary
{
    [Serializable]
    public class NoValueException : Exception
    {
        public NoValueException()
        {
        }

        public NoValueException(string? message) : base(message)
        {
            Console.WriteLine();
        }

        public NoValueException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoValueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}