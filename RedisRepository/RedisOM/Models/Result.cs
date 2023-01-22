using CrudApp.Enums;

namespace RedisOM.Models;

public class Result<T> : Result
{
    public Result()
    {
    }

    public Result(ReturnType type) : base(type)
    {
        Type = type;
    }

    public Result(ReturnType type, T data) : base(type)
    {
        Data = data;
        Type = type;
    }

    public Result(ReturnType type, string description, T data) : base(type)
    {
        Data = data;
        Type = type;
        Description = description;
    }

    public Result(T data) : base(ReturnType.Success)
    {
        Data = data;
        Type = ReturnType.Success;
    }

    public Result(T data, Pagination pagination) : base(ReturnType.Success)
    {
        Data = data;
        Pagination = pagination;
        Type = ReturnType.Success;
    }

    public T? Data { get; set; }
    public bool IsNull => Data == null;
    public Pagination? Pagination { get; private set; }


    public Result<T> SetData(T data)
    {
        Data = data;
        return this;
    }

    public Result<T> SetPagination(Pagination pagination)
    {
        Pagination = pagination;
        return this;
    }

    public Result<T> SetTraceId(Guid traceId)
    {
        TraceId = traceId;
        return this;
    }

    public Result<T> SetReturnType(ReturnType type)
    {
        Type = type;
        return this;
    }

    public Result<T> SetDescription(string description)
    {
        Description = description;
        return this;
    }

    public Result<T> SetErrors(List<string> errors)
    {
        Errors = errors;
        return this;
    }
}

public class Result
{
    public Result()
    {
    }

    public Result(ReturnType type)
    {
        Type = type;
    }

    public ReturnType Type { get; set; }
    public Guid TraceId { get; set; }
    public string Description { get; set; } = string.Empty;
    public List<string> Errors { get; set; } = new List<string>();
}
