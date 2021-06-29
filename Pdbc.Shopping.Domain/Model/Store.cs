using System;

namespace Pdbc.Shopping.Domain.Model
{
    public class Store : BaseEquatableEntity<Store>
    {
        public virtual String Name { get; set; }

        public virtual Address Address { get; set; }

        public virtual Article[] Articles { get; set; }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }
}