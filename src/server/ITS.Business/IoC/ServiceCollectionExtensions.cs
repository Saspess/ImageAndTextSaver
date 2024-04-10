using ITS.Business.Services;
using ITS.Business.Services.Contracts;
using ITS.Data.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ITS.Business.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataLayer(configuration);
            services.AddScoped<IFileDataService, FileDataService>();
            return services;
        }
    }
}
