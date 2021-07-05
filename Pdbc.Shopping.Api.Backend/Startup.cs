using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Pdbc.Shopping.Api.Common.Controllers;
using Pdbc.Shopping.Api.Common.Extensions;
using Pdbc.Shopping.Common.Extensions;
using Pdbc.Shopping.Core;
using Pdbc.Shopping.Data;

namespace Pdbc.Shopping.Api.Backend
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc(options =>
            {
                options.RegisterProducesResponseTypes();
                //options.ReturnHttpNotAcceptable = true;
                options.SetOutputFormatters();

                //options.Filters.Add(new AuthorizeFilter());

            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                ;

            //services.Configure<ApiBehaviorOptions>(options =>
            //{
            //    options.SetInvalidModelStateResponse();
            //});

            //services.AddVersionedApiExplorer(setupAction =>
            //{
            //    setupAction.SetVersionApiExplorer();
            //});

            //services.AddApiVersioning(a => { a.SetVersion(); });

            //services.AddAuthentication("Basic").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("Basic", null);


            services.RegisterModule<ShoppingDataModule>(Configuration);
            services.RegisterModule<ShoppingCoreModule>(Configuration);

            //services.RegisterModule<MusicCqrsServicesModule>(Configuration);
            //services.AddAutoMapper(typeof(RequestToCqrsMappings));

            var serviceProvider = services.BuildServiceProvider(); //.GetService<IApiVersionDescriptionProvider>();
            services.AddSwaggerGen(options =>
            {
                options.ConfigureSwaggerDocument("PDBC.Shopping API",
                    "v1",
                    "API for maintaining articles, stores & shopping list (and other experiments)");

                options.ConfigureSwaggerDocumentationAssemblies(new[]
                {
                    Assembly.GetExecutingAssembly(),
                    Assembly.GetAssembly(typeof(ResourcesController)),
                });

                // TODO Common somewhere - Add filters to fix enums
                //options.AddEnumsWithValuesFixFilters();

                //options.ConfigureOauthFlow(swaggerApiConfiguration.IdpBaseUrl, new Dictionary<string, string>()
                //{
                //    {
                //        "shopping.backend.api", "Access to the shopping backend api"
                //    }
                //});


                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                //a.ConfigureSwaggerAuthentication();
            });

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    // Domain Model classes can have navigation properties leading to cycles
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                    //options.SerializerSettings.Converters.Add(new TrimStringConverter());
                });

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) //, IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();


            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "Pdbc.Music");

                c.DefaultModelExpandDepth(2);
                c.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model);
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                c.EnableDeepLinking();
                c.DisplayOperationId();

                //foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                //{
                //    c.SwaggerEndpoint($"/swagger/" +
                //                                $"PDBC.Music - {description.GroupName}/swagger.json",
                //        description.GroupName.ToUpperInvariant());
                //}
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
