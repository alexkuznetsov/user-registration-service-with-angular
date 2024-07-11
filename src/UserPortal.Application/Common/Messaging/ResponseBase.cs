namespace UserPortal.Application.Common.Messaging;

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

    public ICollection<Failure> Failures { get; } = [];
}
