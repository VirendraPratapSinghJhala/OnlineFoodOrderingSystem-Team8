//=============================================
//  Developer:	<Mehul Jain>
//  Create date: <15th May,2020>
//  Description : To manage Customer Exception.
//=============================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace OnlineFoodOrderingSystem.ExceptionLayer
{
    public class CustomerException : ApplicationException
    {
        public CustomerException()
        {
        }

        public CustomerException(string message) : base(message)
        {
        }

        public CustomerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}