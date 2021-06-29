using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pdbc.Shopping.Data;
using Pdbc.Shopping.Data.Repositories;
using Pdbc.Shopping.Common;

namespace Pdbc.Shopping.Data
{
    public class ShoppingDataModule : IModule
    {
        public void Register(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var settings = new DataSettings(configuration);
            serviceCollection.AddSingleton(settings);

            serviceCollection.AddDbContext<ShoppingDbContext>(options => options.UseSqlServer(
                settings.DbConnectionString, builder =>
                {
                    if (settings.UseRetries)
                    {
                        builder.EnableRetryOnFailure(
                            settings.SqlServerMaxRetryCount,
                            TimeSpan.FromMilliseconds(settings.SqlServerMaxDelay),
                            new List<int>()
                        );
                    }

                    builder.MigrationsHistoryTable(DbConstants.MigrationsTableName, DbConstants.DefaultSchemaName);
                }));


            serviceCollection.AddOptions(); //Is necessary in order for IOptions<T> to work

            // Manually register all repositories
            //serviceCollection.AddScoped<IArtistRepository, ArtistRepository>();
            //serviceCollection.AddScoped<IEntityRepository<Artist>, ArtistRepository>();
            //serviceCollection.AddScoped<IGenreRepository, GenreRepository>();
            //serviceCollection.AddScoped<IEntityRepository<Genre>, GenreRepository>();

            // Scans all classes to register them as its matching interface.
            serviceCollection.Scan(scan => scan.FromAssemblyOf<ShoppingDataModule>()
                .AddClasses(true)
                .AsMatchingInterface()
                .WithScopedLifetime()
            );

            //// Scan register 
            serviceCollection.Scan(scan => scan.FromAssemblyOf<ShoppingDataModule>()
                .AddClasses(classes => classes.AssignableTo(typeof(IEntityRepository<>)).Where(_ => !_.IsGenericType))  // Get all classes inheriting the entity repository
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );

            //serviceCollection.Scan(scan =>
            //    scan.FromAssembliesOf(typeof(ICommandHandler<>))
            //        .AddClasses(classes =>
            //            classes.AssignableTo(typeof(ICommandHandler<>)).Where(_ => !_.IsGenericType))
            //        .AsImplementedInterfaces()
            //        .WithTransientLifetime());

            //serviceCollection.Scan(scan => scan.FromAssemblyOf<ShoppingDataModule>()
            //    .AddClasses(true)
            //    .AsMatchingInterface()
            //    .WithScopedLifetime()
            //);
        }
    }
}