using System;

namespace Pdbc.Shopping.Data.Auditing
{
    /// <summary>
    /// Specific information about a property that was changed
    /// </summary>
    public class PropertyChangesDataInfo 
    {
        /// <summary>
        /// The property that was changed
        /// </summary>
        public String Property { get; set; }

        /// <summary>
        /// The original value of the property
        /// </summary>
        public String PreviousValue { get; set; }

        /// <summary>
        /// The new value of the property
        /// </summary>
        public String NewValue { get; set; }


        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"Property: {Property}, PreviousValue: {PreviousValue}, NewValue: {NewValue}";
        }
    }

}
