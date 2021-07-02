using System.Collections.Generic;
using System.Linq;

namespace Pdbc.Shopping.Api.Contracts.Requests
{
    /// <summary>
    /// DataContract type to transfer a Validation Result containing multiple Validation Messages (e.g. from ValconBag).
    /// </summary>
    public class ValidationResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationResult"/> class.
        /// </summary>
        public ValidationResult()
        {
            Messages = new List<ValidationResultMessage>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationResult"/> class.
        /// </summary>
        public ValidationResult(IEnumerable<ValidationResultMessage> messages)
        {
            Messages = messages;
        }

        /// <summary>
        /// The Validation Messages included in this Validation Result.
        /// </summary>

        public IEnumerable<ValidationResultMessage> Messages { get; set; }

        /// <summary>
        /// Flag to indicate if this Validation Result contains any Error messages.
        /// </summary>
        /// <returns></returns>
        public bool HasErrors()
        {
            return Messages.Any();
        }
    }
}