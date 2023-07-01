using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using EmailSender.Application.Interfaces;

namespace EmailSender.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbConnection");
            services.AddDbContext<MailContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddScoped<IMailContext>(provider =>
                provider.GetService<MailContext>());
            return services;
        }
    }
}
