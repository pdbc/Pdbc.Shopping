using System;

namespace Pdbc.Shopping.Domain.Model
{
    public class Article : BaseEquatableEntity<Store>
    {
        public virtual String Name { get; set; }

        public virtual String Brand { get; set; }
    }
}