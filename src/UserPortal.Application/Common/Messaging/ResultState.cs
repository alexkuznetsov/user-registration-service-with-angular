namespace UserPortal.Application.Common.Messaging;

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
    /// General failure
    /// </summary>
    Failure
}
