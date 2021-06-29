using System;

namespace Pdbc.Shopping.Common.Exceptions
{
    public class ShoppingException : ApplicationException
    {
        protected ShoppingException(string message, Exception exception) : base(message, exception)
        {
        }
    }
}
