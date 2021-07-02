using Pdbc.Shopping.Api.Contracts.Attributes;
using Pdbc.Shopping.Api.Contracts.Enum;

namespace Pdbc.Shopping.Api.Contracts.Requests.Errors
{
    /// <summary>
    /// Request to get the possible errors from the API by language and key
    /// </summary>
    [HttpAction("errorMessages/{Language}/{Key}", Method.Get)]
    public class GetErrorMessageRequest : IShoppingRequest
    {

        /// <summary>
        /// The language in which you want the key 
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        public string Language { get; set; }

        /// <summary>
        /// the error key you want the information for
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public string Key { get; set; }
    }

    /// <summary>
    /// The message in the specific language for the key
    /// </summary>
    /// <seealso cref="ShoppingResponse" />
    public class GetErrorMessageResponse : ShoppingResponse
    {
        /// <summary>
        /// Gets or sets the translation.
        /// </summary>
        /// <value>
        /// The translation. Null if not found.
        /// </value>
        public string Message { get; set; }
    }
}
