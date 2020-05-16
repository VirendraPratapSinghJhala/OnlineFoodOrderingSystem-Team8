using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace OnlineFoodOrderingSystem.ExceptionLayer
{
    public class EmployeeException : ApplicationException
    {
        public EmployeeException()
        {
        }

        public EmployeeException(string message) : base(message)
        {
        }

        public EmployeeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmployeeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}