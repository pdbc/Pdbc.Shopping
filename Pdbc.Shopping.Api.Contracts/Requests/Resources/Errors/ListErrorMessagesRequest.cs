using System.Collections.Generic;
using Pdbc.Shopping.Api.Contracts.Attributes;
using Pdbc.Shopping.Api.Contracts.Enum;

namespace Pdbc.Shopping.Api.Contracts.Requests.Resources.Errors
{
    /// <summary>
    /// Request to retrieve all the possible errors from the API
    /// </summary>
    [HttpAction("errorMessages/{Language}", Method.Get)]
    public class ListErrorMessagesRequest
    {
        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        public string Language { get; set; }
    }

    /// <summary>
    /// all errors in the specific language
    /// </summary>
    /// <seealso cref="ShoppingResponse" />
    public class ListErrorMessagesResponse : ShoppingResponse
    {
        /// <summary>
        /// Gets the messages in the specific language
        /// </summary>
        /// <value>
        /// The resources.
        /// </value>
        public IDictionary<string, string> Resources { get; set; }
    }
}