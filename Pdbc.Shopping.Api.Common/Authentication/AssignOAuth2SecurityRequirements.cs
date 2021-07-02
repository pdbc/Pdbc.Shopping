using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Pdbc.Shopping.Api.Common.Authentication
{
    public class AssignOAuth2SecurityRequirements : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Determine if the operation has the Authorize attribute
            var authorizeAttributes = context.ApiDescription.ActionDescriptor.EndpointMetadata.OfType<AuthorizeAttribute>();
            if (!authorizeAttributes.Any())
                return;

            if (operation.Security != null) return;

            // Initialize the operation.security property
            operation.Security = new List<OpenApiSecurityRequirement>
            {
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                        {
                           
                        }
                    }
                }
            };
        }
    }
}