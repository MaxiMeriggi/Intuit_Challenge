using Intuit.Domain.Entities;
using Intuit.Domain.Repositories;
using Intuit.Infrastructure.MappingProfiles;
using Intuit.Infrastructure.Models;
using Intuit.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Intuit.Infrastructure
{
    public static class ServiceExtension
    {
        public static IServiceCollection ConfigureInfraLayer(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<IntuitChallengeContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });

            services.AddScoped<IRepository<Client>, ClientRepository>();
            services.AddScoped<ISearchRepository<Client>, ClientRepository>();
            services.AddScoped<ICreateOnlyRepository<Error>, ErrorRepository>();
            services.AddAutoMapper(typeof(ClientMapping));

            return services;

        }
    }
}
