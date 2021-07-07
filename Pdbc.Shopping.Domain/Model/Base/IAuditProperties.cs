namespace Pdbc.Shopping.Domain.Model
{
    public interface IAuditProperties
    {
        /// <summary>
        /// Gets or sets the area identifier for which the auditing is happening.
        /// </summary>
        /// <value>
        /// The area object identifier.
        /// </value>
        long AreaId { get; set; }

        /// <summary>
        /// Gets or sets the type of the area for which the auditing is happening.
        /// </summary>
        /// <value>
        /// The type of the get area.
        /// </value>
        string AreaType { get; set; }

        /// <summary>
        /// Gets or sets the get object identifier on which the auditing has happened.
        /// This can be the same as the AreaObjectId, but it can also be a child object.
        /// </summary>
        /// <value>
        /// The object identifier.
        /// </value>
        long ObjectId { get; set; }

        /// <summary>
        /// Gets or sets the type of the object.
        /// </summary>
        /// <value>
        /// The type of the object.
        /// </value>
        string ObjectType { get; set; }

        /// <summary>
        /// Gets or sets the get object information.
        /// This must be end-user readable because it is used in the description.
        /// </summary>
        /// <value>
        /// The object information.
        /// </value>
        string ObjectInfo { get; set; }


        ///// <summary>
        ///// Customer audit event properties to store in along with audit record.
        ///// </summary>
        //CustomAuditEventProperties CustomAuditEventProperties { get; set; }
    }

    public interface ICustomAuditEventProperties
    {

    }
}