using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pdbc.Shopping.Data.Configurations;
using Pdbc.Shopping.Domain.Model;
using Pdbc.Shopping.Domain.Validation;

namespace Pdbc.Shopping.Data.Configurations
{
    internal class ArticlesConfiguration : AuditableIdentifiableMapping<Article>
    {
        public override void Configure(EntityTypeBuilder<Article> builder)
        {
            base.Configure(builder);

            builder.ToTable("Articles");

            builder.Property(e => e.Name)
                .HasMaxLength(ValidationConstants.ArticleNameMaxLength)
                .IsRequired();
            
            builder.HasIndex(e => new { e.Name }).IsUnique();
        }
    }
}