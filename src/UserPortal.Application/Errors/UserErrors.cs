using UserPortal.Application.Common.Messaging;
using UserPortal.Application.Resources;

namespace UserPortal.Application.Errors;

internal static class UserErrors
{
    internal static readonly Failure AlreadyExists = new(ErrorCode: "User.Exits",
                        ErrorMessage: RegisterValidationMessages.ErrorUserExists);
}