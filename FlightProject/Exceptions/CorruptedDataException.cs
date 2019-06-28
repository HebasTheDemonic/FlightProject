using System;
using System.Runtime.Serialization;

namespace FlightProject.Exceptions
{
    [Serializable]
    internal class CorruptedDataException : Exception
    {
        public CorruptedDataException()
        {
        }

        public CorruptedDataException(string message) : base(message)
        {
        }

        public CorruptedDataException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CorruptedDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}