namespace UserPortal.Application.Common.Messaging;

public record Failure(string? ErrorCode, string ErrorMessage, string? PropertyName = null);
