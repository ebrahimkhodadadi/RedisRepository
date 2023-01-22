
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RedisOM.Models;

namespace RedisOM.Service;

public static class RedisService
{
    public static string GetConfigString(IConfiguration configuration)
    {
        return $"{configuration["RedisSettings:Host"]}:{configuration["RedisSettings: Port"]}";
        //var redisSettings = new RedisSettings();

        //if (redisSettings != null)
        //{
        //    redisConnectionUrl = $"{redisSettings.Url}:{redisSettings.Port},password={redisSettings.Password}";
        //}
        //else
        //{
        //    var redisEndpointUrl = (Environment.GetEnvironmentVariable("REDIS_ENDPOINT_URL") ?? "127.0.0.1:6379").Split(':');
        //    var redisHost = redisEndpointUrl[0];
        //    var redisPort = redisEndpointUrl[1];

        //    var redisPassword = Environment.GetEnvironmentVariable("REDIS_PASSWORD");
        //    if (redisPassword != null)
        //    {
        //        redisConnectionUrl = $"{redisHost},password={redisPassword}";
        //    }
        //    else
        //    {
        //        redisConnectionUrl = $"{redisHost}:{redisPort}";
        //    }
        //}
    }
}
