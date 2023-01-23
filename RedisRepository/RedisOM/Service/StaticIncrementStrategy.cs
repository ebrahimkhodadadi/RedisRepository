
namespace RedisOM.Service;

public class StaticIncrementStrategy : IIdGenerationStrategy
{
    public static int Current = 0;
    public string GenerateId()
    {
        return (Current++).ToString();
    }
}
