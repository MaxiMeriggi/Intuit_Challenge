using Intuit.Application.Common.MappingProfiles;
using Intuit.Application.Services;
using Intuit.Application.Services.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace Intuit.Application
{
    public static class ServiceExtension
    {
        public static IServiceCollection ConfigureApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ClientMapping));

            services.AddScoped<IClienteService, ClientService>();

            return services;
        }
    }
}
