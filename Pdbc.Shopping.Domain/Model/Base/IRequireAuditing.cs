using System;

namespace Pdbc.Shopping.Domain.Model
{
    public interface IRequireAuditing
    {
        /// <summary>
        /// Verify if the change should be audited for this property
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        Boolean ShouldAuditPropertyChangeFor(string propertyName);

        /// <summary>
        /// Shoulds the object lifecycle be audited (results in Created/Deleted/Modified events)
        /// </summary>
        /// <returns></returns>
        Boolean ShouldAuditObjectLifecycle();

        /// <summary>
        /// Gets or sets the audit properties.
        /// </summary>
        /// <value>
        /// The audit properties.
        /// </value>
        IAuditProperties GetAuditProperties();
    }
}