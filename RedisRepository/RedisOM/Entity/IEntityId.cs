using Redis.OM.Modeling;

namespace RedisOM.Entity;

public interface IEntityId
{
    [RedisIdField][Indexed] string Id { get; set; }
}