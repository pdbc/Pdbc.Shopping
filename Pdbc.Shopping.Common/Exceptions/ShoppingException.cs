using System;

namespace Pdbc.Shopping.Common.Exceptions
{
    public class ShoppingException : ApplicationException
    {
        public ShoppingException(string message) : base(message)
        {
        }

        public ShoppingException(string message, Exception exception) : base(message, exception)
        {
        }
    }
}
