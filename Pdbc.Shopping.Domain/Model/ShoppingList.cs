using System;
using System.Collections.Generic;

namespace Pdbc.Shopping.Domain.Model
{
    public class ShoppingList : BaseEquatableEntity<ShoppingList>
    {
        public virtual Store Store { get; set; }

        public virtual IList<Article> Articles { get; set; }
    }
}