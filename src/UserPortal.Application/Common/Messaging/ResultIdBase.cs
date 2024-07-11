namespace UserPortal.Application.Common.Messaging;

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
