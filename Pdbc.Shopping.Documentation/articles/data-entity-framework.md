# Data - Entity Framework

For my persistence layer I've opted to use Entity Framework Core.  This is a fairly simple ORM mapper that can be used in most common business applications.

## Entity Framework Configuration
All domain classes have a specific mapping type configuration implementation.  Inheritance can here be used for the common properties that are defined in our domain model (Id, Audit Fields, ... )

```csharp
internal abstract class IdentifiableMapping<T> : IEntityTypeConfiguration<T> where T : Identifiable
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();
    }
}

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

```

## Repository Pattern

I Prefer to use the repository pattern to isolate common data access logic into one place.  Not because this would allow me to switch from data-access implementation, because let's face it who does that.  But I believe it improves testabilty (method verification instead of DbContext mocking/setup) and readability (Linq queries are encapsulated in a single class)

Returning the IQueryable syntax as well allows the defering of the execution of the database call untill it is actually needed


## Database Context

The heart of Entity Framework is the database context in which you define your database sets.  In this case we can override the SaveChanges as well to set the audit fields or perform some validation.