using Microsoft.OpenApi.Models;

namespace EmailSender.Server.Extension
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo
                {
                    Title = "EmailSender API",
                    Version = "v1.0",
                    Description = "",
                    Contact = new OpenApiContact
                    {
                        Name = "Name"
                    }
                });

                c.ResolveConflictingActions(apiDesription => apiDesription.First());
            });
        }
        public static void ConfigureResponseCaching(this IServiceCollection services)
        {
            services.AddResponseCaching();
        }
    }
}