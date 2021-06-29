using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pdbc.Shopping.Data;
using Pdbc.Shopping.Data.Configurations;
using Pdbc.Shopping.Data.Interceptors;
using Pdbc.Shopping.Common;
using Pdbc.Shopping.Data.Exceptions;
using Pdbc.Shopping.Domain.Model;

namespace Pdbc.Shopping.Data
{
    public class ShoppingDbContext : DbContext
    {
        private readonly ILogger<ShoppingDbContext> _logger;

        public ShoppingDbContext(DbContextOptions<ShoppingDbContext> options) : base(options)
        {
        }

        public ShoppingDbContext(DbContextOptions<ShoppingDbContext> options, 
            ILogger<ShoppingDbContext> logger) : base(options)
        {
            _logger = logger;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(DbConstants.DefaultSchemaName);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArticlesConfiguration).Assembly);

            //modelBuilder.SetupInitialData();
            //modelBuilder.Entity<Artist>().HasData(new Artist());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLoggerFactory()
            // TODO put this behaind configuration

            optionsBuilder.LogTo(Console.WriteLine)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();

            optionsBuilder.AddInterceptors(new DatabaseCommandInterceptor());
            base.OnConfiguring(optionsBuilder);
        }

        #region DbSets

        public DbSet<Article> Articles { get; set; }
        public DbSet<Address> Addressses { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<ShoppingList> ShoppingLists { get; set; }

        #endregion //DbSets

        public override int SaveChanges()
        {
            try
            {
                ValidateEntities();
                HandleCreatableEntities();
                HandleModifiableEntities();

                return base.SaveChanges();
            }
            catch (InvalidOperationException invalidOperationException)
            {
                // Handle exception and translate to logical named exceptions.
                ThrowErrorWhenDependentObjectStillUsedException(invalidOperationException);

                throw;
            }
            catch (ValidationException dbEntityValidationException)
            {
                _logger.LogError($"TokenDbContext.SaveChanges failed: Validation failed: {dbEntityValidationException.ValidationResult}");
                throw;
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                _logger.LogError($"Optimistic locking failed", dbUpdateConcurrencyException);
                throw;
            }
            catch (DbUpdateException dbUpdateException)
            {
                ThrowErrorWhenDependentObjectStillUsedException(dbUpdateException);
                ThrowErrorWhenUniqueIndexViolated(dbUpdateException);

                throw;
            }


        }

        #region Private Helpers

        private void ValidateEntities()
        {
            var entities = ChangeTracker.Entries().
                Where(s => s.State == EntityState.Added || s.State == EntityState.Modified)
                .Select(x => x.Entity);

            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(entity, validationContext);
            }
        }

        private void HandleCreatableEntities()
        {
            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Added))
            {
                if (!(entry.Entity is ICreatable creatable)) continue;

                creatable.CreatedBy = GetExecutingUserName();
                creatable.CreatedOn = DateTimeOffset.Now;

                if (entry.Entity is IModifiable modifiable)
                {
                    modifiable.ModifiedBy = creatable.CreatedBy;
                    modifiable.ModifiedOn = creatable.CreatedOn;
                }
            }
        }

        private void HandleModifiableEntities()
        {
            foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Modified))
            {
                if (entry.Entity is IModifiable modifiable)
                {
                    // Store ModifiedOn date for Optimistic Locking
                    entry.Property(nameof(modifiable.ModifiedOn)).OriginalValue = modifiable.ModifiedOn;

                    // Save values for Modification.
                    modifiable.ModifiedBy = GetExecutingUserName();
                    modifiable.ModifiedOn = DateTimeOffset.Now;
                }

                if (!(entry.Entity is ICreatable creatable)) continue;

                // must be set for required validation, but will not be saved
                entry.Property(nameof(creatable.CreatedBy)).OriginalValue = "AsCreated";
                entry.Property(nameof(creatable.CreatedBy)).IsModified = false;
                entry.Property(nameof(creatable.CreatedOn)).IsModified = false;
            }
        }

        private string GetExecutingUserName()
        {
            return UserContext.GetUsername();
        }

        private void ThrowErrorWhenDependentObjectStillUsedException(Exception ex)
        {
            if (ex.Message.Contains("When a change is made to a relationship, the related foreign-key property is set to a null value."))
            {
                throw new DependentObjectStillUsedException(ex);
            }

            if (ex.InnerException != null)
            {
                ThrowErrorWhenDependentObjectStillUsedException(ex.InnerException);
            }
        }

        private void ThrowErrorWhenUniqueIndexViolated(Exception ex)
        {
            //duplicate key row in object 'dbo.Profile' with unique index
            if (ex.Message.Contains("duplicate key") && ex.Message.Contains("unique index"))
            {
                throw new UniqueKeyViolationException(ex.Message, ex);
            }

            if (ex.InnerException != null)
            {
                ThrowErrorWhenUniqueIndexViolated(ex.InnerException);
            }
        }

        #endregion //Private Helpers


    }
}

