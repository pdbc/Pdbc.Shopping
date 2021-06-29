using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pdbc.Shopping.Domain.Model;

namespace Pdbc.Shopping.Data.Configurations
{
    internal class AddressesConfiguration : AuditableIdentifiableMapping<Address>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            base.Configure(builder);

            builder.ToTable("Addresses");
        }
    }
}