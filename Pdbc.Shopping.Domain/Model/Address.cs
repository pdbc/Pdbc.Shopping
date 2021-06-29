using System;
using Pdbc.Shopping.Domain.Model;

namespace Pdbc.Shopping.Domain.Model
{
    public class Address : BaseEquatableEntity<Address>
    {
        public virtual String Street { get; set; }
        public virtual String Number { get; set; }
        public virtual String City { get; set; }

        
    }
}