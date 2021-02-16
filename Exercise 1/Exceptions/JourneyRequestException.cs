using System;
using System.Runtime.Serialization;

namespace Exercise_1
{
    [Serializable]
    internal class JourneyRequestException : Exception
    {
        public JourneyRequestException()
        {
        }

        public JourneyRequestException(string message) : base(message)
        {
        }

        public JourneyRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected JourneyRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}