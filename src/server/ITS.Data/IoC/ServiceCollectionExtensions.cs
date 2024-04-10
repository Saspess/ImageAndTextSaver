using ITS.Data.Constants;
using ITS.Data.Models.Configuration;
using ITS.Data.Repositories;
using ITS.Data.Repositories.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ITS.Data.IoC
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FileStorageSettings>(options => configuration.GetSection(SectionNames.FileStorageSettings));
            services.AddScoped<ITextFileDataRepository, TextFileDataRepository>();
            services.AddScoped<IImageFileDataRepository, ImageFileDataRepository>();
            return services;
        }
    }
}
