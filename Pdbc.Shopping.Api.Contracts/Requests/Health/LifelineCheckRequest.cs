using Pdbc.Shopping.Api.Contracts.Attributes;
using Pdbc.Shopping.Api.Contracts.Enum;

namespace Pdbc.Shopping.Api.Contracts.Requests.Health
{
    /// <summary>
    /// Request to verify if the service is running
    /// </summary>
    [HttpAction("health/lifelinecheck", Method.Get)]
    public class LifelineCheckRequest : IShoppingRequest
    {

    }

    /// <summary>
    /// The response if the service in running
    /// </summary>
    /// <seealso cref="ShoppingResponse" />
    public class LifelineCheckResponse : ShoppingResponse
    {

    }
}
