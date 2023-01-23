namespace RedisOM.Models;

public record Pagination(int Limit, int Offset, long Count);
