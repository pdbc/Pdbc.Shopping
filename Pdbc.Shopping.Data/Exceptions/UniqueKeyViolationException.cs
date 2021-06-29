using System;
using Pdbc.Shopping.Common.Exceptions;

namespace Pdbc.Shopping.Data.Exceptions
{
    public class UniqueKeyViolationException : ShoppingException
    {
        public UniqueKeyViolationException(string message, Exception innerException) 
            : base(message, innerException)
        {

        }
    }
}