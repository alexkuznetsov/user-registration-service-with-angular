namespace UserPortal.IntergrationTests.Data;
internal class Models
{
    public static IEnumerable<object[]> InvalidRegistrationRequests =>
    [
        [ new UserRegisterRequest {
            AgreeToWork=true,
            Login="qwe@",
            Password="123q",
            Password2="123q",
            ProvinceId =Provinces.KZ_EastKazakhstan
        }, UserPortal.Application.Resources.RegisterValidationMessages.EmailMustBeValid],

        [ new UserRegisterRequest {
            AgreeToWork=true,
            Login="qwe@qwer",
            Password="123",
            Password2="123",
            ProvinceId =Provinces.KZ_EastKazakhstan
        }, UserPortal.Application.Resources.RegisterValidationMessages.PasswordMustBeAtLeastOneNumAndOneChar ]
    ];

}


public class UserRegisterRequest
{
    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Password2 { get; set; } = null!;

    public bool? AgreeToWork { get; set; }

    public Guid? ProvinceId { get; set; }
}