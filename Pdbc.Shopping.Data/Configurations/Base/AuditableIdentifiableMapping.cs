using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pdbc.Shopping.Domain.Model;

namespace Pdbc.Shopping.Data.Configurations
{
    internal abstract class AuditableIdentifiableMapping<T> : IdentifiableMapping<T> where T : AuditableIdentifiable
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.CreatedBy)
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(e => e.CreatedOn)
                .HasColumnType("datetimeoffset")
                .IsRequired();
            builder.Property(e => e.ModifiedBy)
                .HasMaxLength(255)
                .IsRequired();
            builder.Property(e => e.ModifiedOn)
                .IsRequired()
                .HasColumnType("datetimeoffset")
                .IsConcurrencyToken();
        }
    }
}