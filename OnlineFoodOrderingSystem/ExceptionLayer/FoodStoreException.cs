using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace OnlineFoodOrderingSystem.ExceptionLayer
{
    public class FoodStoreException : ApplicationException
    {
        public FoodStoreException()
        {
        }

        public FoodStoreException(string message) : base(message)
        {
        }

        public FoodStoreException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FoodStoreException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}