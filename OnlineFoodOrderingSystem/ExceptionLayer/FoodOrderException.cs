using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace OnlineFoodOrderingSystem.ExceptionLayer
{
    public class FoodOrderException : ApplicationException
    {
        public FoodOrderException()
        {
        }

        public FoodOrderException(string message) : base(message)
        {
        }

        public FoodOrderException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FoodOrderException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}