using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Pe2.Infra.DbSettings;

namespace Pe2Api.Extensions
{
    public static class MongoDbExtensions
    {    

        public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {            
            services.Configure<MongoSettings>(configuration.GetSection("MongoSettings"));
            services.AddSingleton<IMongoSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<MongoSettings>>().Value);
            return services;
        }
    }
}
