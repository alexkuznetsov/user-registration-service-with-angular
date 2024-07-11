namespace LoginPage.Application.Common.Messaging;

public enum ResultState
{
    /// <summary>
    /// Operation successfull
    /// </summary>
    Ok,
    /// <summary>
    /// Operation result - not found
    /// </summary>
    NotFound,
    /// <summary>
    /// Operation result - forbidden
    /// </summary>
    Forbidden,
    /// <summary>
    /// General failure
    /// </summary>
    Failure
}

public abstract class ResponseBase
{
    public ResultState State { get; set; }
    public ResponseBase() : this(ResultState.Ok)
    {
    }

    public ResponseBase(ResultState state)
    {
        State = state;
    }

    public ICollection<Failure> Failures { get; }
        = new List<Failure>();
}

public class Failure
{
    public string ErrorMessage { get; set; } = "";
    public string? ErrorCode { get; set; }
    public string? PropertyName { get; set; }
}


public abstract class ResultBase<TBase> : ResponseBase
    where TBase : ResultBase<TBase>, new()
{
    private static readonly Func<TBase> NotFoundVal = () => new() { State = ResultState.NotFound };
    private static readonly Func<TBase> OkVal = () => new() { State = ResultState.Ok };
    private static readonly Func<TBase> ForbiddenVal = () => new() { State = ResultState.Forbidden };
    private static readonly Func<TBase> FailureVal = () => new() { State = ResultState.Failure };

    public static TBase CreateNotFound() => NotFoundVal();
    public static TBase CreateForbidden() => ForbiddenVal();
    public static TBase CreateFailure() => FailureVal();
    public static TBase CreateFailure(params Failure[] failures)
    {
        var r = FailureVal();
        for (int i = 0; i < failures.Length; i++)
        {
            r.Failures.Add(failures[i]);
        }
        return r;
    }
    public static TBase Ok() => OkVal();

    public ResultBase() : base()
    {

    }

    public ResultBase(ResultState state) : base(state)
    {

    }


    public bool IsNotFound() => this.State == ResultState.NotFound;
    public bool IsForbidden() => this.State == ResultState.Forbidden;
    public bool IsOk() => this.State == ResultState.Ok;
}

public abstract class ResultIdBase<TBase, TResult> : ResultBase<TBase>
     where TBase : ResultIdBase<TBase, TResult>, new()
     where TResult : struct
{
    public TResult Id { get; set; }

    public ResultIdBase() : base(ResultState.Ok) { }

    public static TBase Ok(TResult entity)
    {
        var tbase = new TBase() { Id = entity };
        return tbase;
    }
}

public abstract class ResultBase<TBase, TResult> : ResultBase<TBase>
     where TBase : ResultBase<TBase, TResult>, new()
     where TResult : class
{
    public ResultBase() : base(ResultState.Ok) { }

    public TResult Result { get; set; } = null!;

    public static TBase Ok(TResult entity)
    {
        var tbase = new TBase() { Result = entity };
        return tbase;
    }
}