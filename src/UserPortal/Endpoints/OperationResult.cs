using UserPortal.Application.Common.Messaging;

namespace UserPortal.Endpoints;

public class OperationResult
{
    public static readonly OperationResult SuccessResult = new();

    public bool Success { get; }
    public string Message { get; }

    public Failure[] Failures { get; }

    public OperationResult(string message = "Success") : this(true, message, []) { }

    public OperationResult(bool success, string message, Failure[] failures)
    {
        Success = success;
        Message = message;
        Failures = failures;
    }
}