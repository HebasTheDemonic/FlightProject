using System;
using System.Runtime.Serialization;

namespace FlightProject
{
    [Serializable]
    internal class UnregisteredUserException : Exception
    {
        public UnregisteredUserException()
        {
        }

        public UnregisteredUserException(string message) : base(message)
        {
        }

        public UnregisteredUserException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnregisteredUserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}