using System;
using Pdbc.Shopping.Common.Exceptions;

namespace Pdbc.Shopping.Data.Exceptions
{
    public class DependentObjectStillUsedException : ShoppingException
    {
        public DependentObjectStillUsedException(Exception exception) : base("DependentObjectStillUsed", exception)
        {

        }
    }
}
