using UserPortal.Application.Common.Messaging;
using UserPortal.Application.Resources;

namespace UserPortal.Application.Errors;
internal class ProvinceErrors
{
    internal static readonly Failure NotFound = new(ErrorCode: "Province.NotFound",
                        ErrorMessage: RegisterValidationMessages.ErrorProvinceNotFound);
}
