namespace UserPortal.Application.Common.Messaging;

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