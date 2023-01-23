using Redis.OM.Modeling;
using RedisOM.Service;

namespace RedisOM.Entity;

//[Document(StorageType = StorageType.Json, IdGenerationStrategyName = nameof(StaticIncrementStrategy), Prefixes = new[] { "Rose" })]
[Document(StorageType = StorageType.Json, Prefixes = new[] { "Rose" })]
public class RoseEntity : IEntity<RoseEntity>, IVersionAbleEntity
{
    [RedisIdField]
    [Indexed]
    public string? Id { get; set; }
    public int Version { get; set; }
    [Indexed(CaseSensitive = false)]
    public string Name { get; set; } = string.Empty;
    [Searchable]
    public string Description { get; set; } = string.Empty;
    public IList<KeyValuePair<string, string>> GetChanges(RoseEntity oldOne)
    {
        throw new NotImplementedException();
    }
}