

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Redis.OM.Modeling;
using RedisOM.Repository;
using RedisOM.Service;
using StackExchange.Redis;

namespace RedisOM;

public static class ServiceExtensions
{
    public static void AddRedis(this IServiceCollection services, IConfiguration configuration)
    {
        var redisConfig = RedisService.GetConfigString(configuration);
        
        services.AddSingleton(new RedisConnectionProvider(redisConfig));
        
        services.AddSingleton<IDatabase>(cfg =>
        {
            IConnectionMultiplexer multiplexer = ConnectionMultiplexer.Connect(redisConfig);
            return multiplexer.GetDatabase();
        });

        services.AddHostedService<CreateIndexHostedService>();
        
        services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));

        // get id filed value
        //DocumentAttribute.RegisterIdGenerationStrategy(nameof(StaticIncrementStrategy), new StaticIncrementStrategy());
    }
}
