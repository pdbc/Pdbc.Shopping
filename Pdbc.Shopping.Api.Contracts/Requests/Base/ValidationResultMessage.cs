using System;

namespace Pdbc.Shopping.Api.Contracts.Requests
{
    /// <summary>
    /// Data contract to signal a message of the validation result
    /// </summary>
    public class ValidationResultMessage
    {
        /// <summary>
        /// The Error code of the validation message
        /// </summary>
        public String Key { get; set; }

        /// <summary>
        /// The message of the validation error
        /// </summary>
        public String Message { get; set; }
    }
}