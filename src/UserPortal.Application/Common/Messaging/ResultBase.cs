namespace UserPortal.Application.Common.Messaging;

public abstract class ResultBase<TBase> : ResponseBase
    where TBase : ResultBase<TBase>, new()
{
    private static readonly Func<TBase> NotFoundVal = () => new() { State = ResultState.NotFound };
    private static readonly Func<TBase> OkVal = () => new() { State = ResultState.Ok };
    private static readonly Func<TBase> FailureVal = () => new() { State = ResultState.Failure };

    public static TBase CreateNotFound() => NotFoundVal();
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
    public bool IsOk() => this.State == ResultState.Ok;
}
