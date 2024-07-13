namespace UserPortal.IntergrationTests.FailureModels;

internal class TypedRegistrationProblemDetail
{
    public bool Success { get; set; }
    public string Message { get; set; } = null!;
    public Failure[] Failures { get; set; } = [];
}
