using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pdbc.Shopping.Domain.Model;
using Pdbc.Shopping.Domain.Validation;

namespace Pdbc.Shopping.Data.Configurations
{
    internal class StoresConfiguration : AuditableIdentifiableMapping<Store>
    {
        public override void Configure(EntityTypeBuilder<Store> builder)
        {
            base.Configure(builder);

            builder.ToTable("Stores");

            builder.Property(e => e.Name)
                .HasMaxLength(ValidationConstants.StoreNameMaxLength)
                .IsRequired();

            builder.HasIndex(e => new { e.Name }).IsUnique();

        }
    }
}