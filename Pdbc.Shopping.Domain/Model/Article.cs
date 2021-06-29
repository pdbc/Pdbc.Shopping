using System;

namespace Pdbc.Shopping.Domain.Model
{
    public class Article : BaseEquatableEntity<Article>
    {
        public virtual String Name { get; set; }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }
}