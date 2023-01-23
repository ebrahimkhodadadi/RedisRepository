
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RedisOM.Models;
using StackExchange.Redis;

namespace RedisOM.Service;

public static class RedisService
{
    public static ConfigurationOptions GetConfigString(IConfiguration configuration)
    {
        var model = new ConfigurationOptions()
        {
            EndPoints = { string.Concat(configuration["RedisSettings:Host"], ":", configuration["RedisSettings:Port"]) },
            AbortOnConnectFail = Convert.ToBoolean(configuration["RedisSettings:AbortOnConnectFail"]),
            AsyncTimeout = Convert.ToInt32(configuration["RedisSettings:AsyncTimeOutMilliSecond"]),
            ConnectTimeout = Convert.ToInt32(configuration["RedisSettings:ConnectTimeOutMilliSecond"])
        };

        if (!string.IsNullOrEmpty(configuration["RedisSettings:User"]))
        {
            model.User = configuration["RedisSettings:User"];
        }
        if (!string.IsNullOrEmpty(configuration["RedisSettings:Password"]))
        {
            model.Password = configuration["RedisSettings:Password"];
        }

        return model;
        
    }
}
