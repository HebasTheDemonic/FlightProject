using System;
using System.Runtime.Serialization;

namespace FlightProject.Exceptions
{
    [Serializable]
    public class UnauthorisedActionException : Exception
    {
        internal UnauthorisedActionException()
        {
        }

        internal UnauthorisedActionException(string message) : base(message)
        {
        }

        internal UnauthorisedActionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UnauthorisedActionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}