using SurveyBasket.Application.Abstractions.Abstractions.Const;

namespace SurveyBasket.Application.Validations.Auth
{
    public class ResetPasswordRequestValidator : AbstractValidator<ResetPasswordRequest>
    {
        public ResetPasswordRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.ResetCode)
                .NotEmpty();

            RuleFor(x => x.NewPassword)
                .NotEmpty()
                .Matches(RegexPatterns.Password)
                .WithMessage("Password must be at least 8 digits  and contain at least one uppercase letter, one lowercase letter, one digit and one special character ");

        }
    }
}
