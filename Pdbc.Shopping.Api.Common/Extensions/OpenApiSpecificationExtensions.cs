using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Pdbc.Shopping.Api.Common.Extensions
{
    public static class OpenApiSpecificationExtensions
    {
        public static void ConfigureSwaggerDocument(this SwaggerGenOptions options,
                string title,
                string version,
                string description
            )
        {

            options.SwaggerDoc(
                version,
                new OpenApiInfo
                {
                    Title = title,
                    Version = version,
                    Description = description
                });
        }

        public static void ConfigureSwaggerDocumentationAssemblies(this SwaggerGenOptions options,
            Assembly[] assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var xmlFile = $"{assembly.GetName().Name}.xml";
                var file = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (File.Exists(file))
                    options.IncludeXmlComments(file);
            }
        }

        public static void RegisterProducesResponseTypes(this MvcOptions options)
        {

            options.Filters.Add(
                new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
            options.Filters.Add(
                new ProducesResponseTypeAttribute(StatusCodes.Status401Unauthorized));
            options.Filters.Add(
                new ProducesResponseTypeAttribute(StatusCodes.Status403Forbidden));
            options.Filters.Add(
                new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));
            options.Filters.Add(
                new ProducesDefaultResponseTypeAttribute());


        }

        public static void ConfigureSecurityDefinitionBasicAuth(this SwaggerGenOptions options)
        {
            options.AddSecurityDefinition("basicAuth", new OpenApiSecurityScheme()
            {
                Type = SecuritySchemeType.Http,
                Scheme = "basic",
                Description = "Input your username and password to access this API"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference {
                            Type = ReferenceType.SecurityScheme,
                            Id = "basicAuth" }
                    }, new List<string>() }
            });
        }

        //public static void ConfigureSwaggerGeneration(this SwaggerGenOptions options, 
        //    ServiceProvider serviceProvider, 
        //    String name, 
        //    String title, 
        //    String description,
        //    IEnumerable<Assembly> assembliesWithXmlDocumentation)
        //{
        //    var apiVersionDescriptionProvider = serviceProvider.GetService<IApiVersionDescriptionProvider>();
        //    if (apiVersionDescriptionProvider != null)
        //    {
        //        foreach (var apiVersionDescription in apiVersionDescriptionProvider.ApiVersionDescriptions)
        //        {
        //            ConfigureSwaggerDocument(options, $"{name}{apiVersionDescription.GroupName}", title, apiVersionDescription.ApiVersion.ToString(), description);
        //        }
        //    }
        //    else
        //    {
        //        ConfigureSwaggerDocument(options, name, title, "V1", description);
        //    }

        //    //options.DocInclusionPredicate((documentName, apiDescription) =>
        //    //{
        //    //    var actionApiVersionModel = apiDescription.ActionDescriptor
        //    //        .GetApiVersionModel(ApiVersionMapping.Explicit | ApiVersionMapping.Implicit);

        //    //    if (actionApiVersionModel == null)
        //    //    {
        //    //        return true;
        //    //    }

        //    //    if (actionApiVersionModel.DeclaredApiVersions.Any())
        //    //    {
        //    //        return actionApiVersionModel.DeclaredApiVersions.Any(v =>
        //    //            $"{name}{v.ToString()}" == documentName);
        //    //    }
        //    //    return actionApiVersionModel.ImplementedApiVersions.Any(v =>
        //    //        $"{name}{v.ToString()}" == documentName);
        //    //});



        //    foreach (var assembly in assembliesWithXmlDocumentation)
        //    {
        //        var xmlFile = $"{assembly.GetName().Name}.xml";
        //        var file = Path.Combine(AppContext.BaseDirectory, xmlFile);
        //        if (File.Exists(file))
        //            options.IncludeXmlComments(file);
        //    }

        //}

        //private static void ConfigureSwaggerDocument(SwaggerGenOptions options, 
        //    string name, 
        //    string title, 
        //    string version,
        //    string description)
        //{
        //    options.SwaggerDoc(
        //        version, // name
        //        new Microsoft.OpenApi.Models.OpenApiInfo()
        //        {
        //            Title = title,
        //            Version = version,
        //            Description = description,
        //            Contact = new Microsoft.OpenApi.Models.OpenApiContact()
        //            {
        //                Email = "patrick@allors.com",
        //                Name = "Patrick De Boeck",
        //                Url = new Uri("https://twitter.com/patrickdeboeck")
        //            },
        //            License = new Microsoft.OpenApi.Models.OpenApiLicense()
        //            {
        //                Name = "MIT License",
        //                Url = new Uri("https://opensource.org/licenses/MIT")
        //            }
        //        });
        //}





        //public static void ConfigureSecurityDefinitionOauth(this SwaggerGenOptions options, string idpUrl,
        //    IDictionary<string, string> scopes)
        //{
        //    // authorization info
        //    var authorizeUrl = $"{idpUrl}oidc/v1/authorize";
        //    var tokenUrl = $"{idpUrl}oidc/v1/token";


        //    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
        //    {
        //        Type = SecuritySchemeType.OAuth2,
        //        Flows = new OpenApiOAuthFlows
        //        {
        //            AuthorizationCode = new OpenApiOAuthFlow
        //            {
        //                AuthorizationUrl = new Uri(authorizeUrl),
        //                TokenUrl = new Uri(tokenUrl),
        //                Scopes = scopes
        //            },

        //            //Implicit = new OpenApiOAuthFlow
        //            //{
        //            //    AuthorizationUrl = new Uri(authorizeUrl, UriKind.Absolute),
        //            //    Scopes = scopes,
        //            //}
        //        }
        //    });
        //    options.OperationFilter<AssignOAuth2SecurityRequirements>();
        //}


        //public static void ConfigureOauthInSwaggerUi(this SwaggerUIOptions options,
        //    String name,
        //    String clientId,
        //    String clientSecret)
        //{
        //    options.OAuthClientId(clientId);
        //    options.OAuthClientSecret(clientSecret);
        //    options.OAuthAppName(name);
        //    //options.OAuthScopeSeparator(" ");
        //    options.OAuthUsePkce();
        //}
    }
}
