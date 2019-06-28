using System;
using System.Runtime.Serialization;

namespace FlightProject.Exceptions
{
    [Serializable]
    internal class UnregisteredDataException : Exception
    {
        public UnregisteredDataException()
        {
        }

        public UnregisteredDataException(string message) : base(message)
        {
        }

        public UnregisteredDataException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnregisteredDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}