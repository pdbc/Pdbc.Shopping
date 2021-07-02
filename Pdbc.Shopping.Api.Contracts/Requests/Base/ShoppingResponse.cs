namespace Pdbc.Shopping.Api.Contracts.Requests
{
    /// <summary>
    /// A response coming from the PDBC.Music API
    /// </summary>
    public interface IShoppingResponse
    {
        /// <summary>
        /// information about the success of the request
        /// </summary>
        ValidationResult Notifications { get; set; }
    }

    /// <inheritdoc />
    public class ShoppingResponse : IShoppingResponse
    {
        /// <inheritdoc />
        public ValidationResult Notifications { get; set; }
    }
}