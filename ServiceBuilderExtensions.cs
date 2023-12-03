using Maniceraf.SimpleMongoDbLogger.Models;
using Maniceraf.SimpleMongoDbLogger.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Maniceraf.SimpleMongoDbLogger
{
    public static class ServiceBuilderExtensions
    {
        public static IServiceCollection AddSimpleMongoDbLogger(this IServiceCollection services, string collectionString, string databaseName)
        {
            services.AddSingleton<IMongoDbLogger>(provider => new MongoDbLogger(collectionString, databaseName));
            return services;
        }

        public static IServiceCollection AddSimpleMongoDbLogger(this IServiceCollection services, string collectionString, string databaseName, string collectionName)
        {
            services.AddSingleton<IMongoDbLogger>(provider => new MongoDbLogger(collectionString, databaseName, collectionName));
            return services;
        }

        public static IServiceCollection AddSimpleMongoDbLogger(this IServiceCollection services, Action<MongoDbLoggerSettings> settings)
        {
            services.Configure<MongoDbLoggerSettings>(settings);
            services.AddSingleton<IMongoDbLogger, MongoDbLogger>();
            return services;
        }
    }
}
