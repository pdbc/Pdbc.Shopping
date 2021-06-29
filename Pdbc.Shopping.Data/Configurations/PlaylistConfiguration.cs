using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pdbc.Shopping.Domain.Model;

namespace Pdbc.Shopping.Data.Configurations
{
    internal class ShoppingListsConfiguration : AuditableIdentifiableMapping<ShoppingList>
    {
        public override void Configure(EntityTypeBuilder<ShoppingList> builder)
        {
            base.Configure(builder);

            builder.ToTable("ShoppingLists");
        }
    }
}