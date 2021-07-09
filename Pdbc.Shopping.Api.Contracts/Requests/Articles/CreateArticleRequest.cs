using Pdbc.Shopping.Api.Contracts.Attributes;
using Pdbc.Shopping.Api.Contracts.Enum;
using Pdbc.Shopping.DTO.Articles;

namespace Pdbc.Shopping.Api.Contracts.Requests.Articles
{
    /// <summary>
    /// Request to get the possible errors from the API by language and key
    /// </summary>
    [HttpAction("articles", Method.Post)]
    public class CreateArticleRequest : IShoppingRequest
    {

        /// <summary>
        /// The language in which you want the key 
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        public ArticleCreateDto Article { get; set; }

    }

    /// <summary>
    /// The message in the specific language for the key
    /// </summary>
    /// <seealso cref="ShoppingResponse" />
    public class CreateArticleResponse : ShoppingResponse
    {

    }
}