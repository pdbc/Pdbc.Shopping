using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Pdbc.Shopping.Api.Common.Attributes
{
    /// <summary>
    /// Marker attribute to specify the TimeOut setting of the action
    /// </summary>
    /// <seealso cref="System.Attribute" />
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public class ActionTimeoutAttribute : Attribute, IFilterMetadata
    {
        public long Timeout { get; }

        public ActionTimeoutAttribute(long timeout)
        {
            Timeout = timeout;
        }
    }
}