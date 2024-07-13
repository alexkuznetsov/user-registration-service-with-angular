using System.Text.RegularExpressions;

using FluentValidation;

using UserPortal.Application.Resources;

namespace UserPortal.Application.Users.Commands;
public static partial class UserSave
{
    public partial class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.Login)
            .NotEmpty()
                .WithMessage(RegisterValidationMessages.EmailCantBeNull)
            .MinimumLength(3)
                .WithMessage(RegisterValidationMessages.EmailMustBe3AndMoreChars)
            .EmailAddress()
                .WithMessage(RegisterValidationMessages.EmailMustBeValid);

            RuleFor(x => x.Password)
                .NotEmpty()
                    .WithMessage(RegisterValidationMessages.PasswordCannotBeNullOrEmpty)
                .MinimumLength(2)
                    .WithMessage(RegisterValidationMessages.PasswordMustBeAtLeast2Symbols)
                .Custom(ValidateEmailComplexity);

            RuleFor(x => x.Password2)
                .Equal(r => r.Password)
                    .WithMessage(RegisterValidationMessages.PasswordAndPassw2MustBeSame);

            RuleFor(x => x.AgreeToWork)
                .Equal(r => true)
                    .WithMessage(RegisterValidationMessages.YouMustBeAgreeToWork);

            RuleFor(x => x.ProvinceId)
                .NotNull()
                    .WithMessage(RegisterValidationMessages.ProvinceCanNotBeNullOrEmpty)
                .NotEmpty()
                    .WithMessage(RegisterValidationMessages.ProvinceCanNotBeNullOrEmpty);
        }

        private void ValidateEmailComplexity(string password, ValidationContext<Command> validationContext)
        {
            if (!PasswordComplexityRegex().IsMatch(password))
            {
                validationContext.AddFailure(new FluentValidation.Results.ValidationFailure(nameof(Command.Password),
                    RegisterValidationMessages.PasswordMustBeAtLeastOneNumAndOneChar));
            }
        }

        [GeneratedRegex("^(?=.*[0-9])(?=.*[a-zA-Z])([a-zA-Z0-9]+)$", RegexOptions.Compiled)]
        private static partial Regex PasswordComplexityRegex();
    }
}
