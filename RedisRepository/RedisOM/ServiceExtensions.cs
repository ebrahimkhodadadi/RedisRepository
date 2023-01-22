

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedisOM.Repository;
using RedisOM.Service;
using StackExchange.Redis;

namespace RedisOM;

public static class ServiceExtensions
{
    public static void AddRedis(this IServiceCollection services, IConfiguration configuration)
    {
        string redisPort = RedisService.GetConfigString(configuration);

        services.AddSingleton(new RedisConnectionProvider(new ConfigurationOptions
        { 
            EndPoints = { redisPort } 
        }));
        
        services.AddSingleton<IDatabase>(cfg =>
        {
            IConnectionMultiplexer multiplexer = ConnectionMultiplexer.Connect(redisPort);
            return multiplexer.GetDatabase();
        });

        services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
    }
}
