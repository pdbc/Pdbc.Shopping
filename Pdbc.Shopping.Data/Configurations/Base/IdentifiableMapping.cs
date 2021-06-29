using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pdbc.Shopping.Domain.Model;

namespace Pdbc.Shopping.Data.Configurations
{
    internal abstract class IdentifiableMapping<T> : IEntityTypeConfiguration<T> where T : Identifiable
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                   .ValueGeneratedOnAdd();
        }
    }
}
