using ITS.Services.Services;
using ITS.Services.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace ITS.Services.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddClientServices(this IServiceCollection services)
        {
            services.AddScoped<IMessageService, MessageService>();
            return services;
        }
    }
}
