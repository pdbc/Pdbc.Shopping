using System;
using System.Net;

namespace Pdbc.Shopping.Api.ServiceAgent.Exceptions
{
    public class ServiceAgentException : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public string Body { get; }

        public ServiceAgentException(HttpStatusCode statusCode, String errorMessage, String body) : base(errorMessage)
        {
            StatusCode = statusCode;
            Body = body;
        }
    }
}
