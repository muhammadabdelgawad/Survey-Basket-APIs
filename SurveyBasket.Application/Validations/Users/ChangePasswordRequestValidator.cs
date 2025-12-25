using SurveyBasket.Application.Abstractions.Abstractions.Const;
using SurveyBasket.Application.Abstractions.DTOs.Users.Request;

namespace SurveyBasket.Application.Validations.Users
{
    public class ChangePasswordRequestValidator :AbstractValidator<ChangePasswordRequest>
    {
        public ChangePasswordRequestValidator()
        {
            RuleFor(p => p.CurrentPassword)
                .NotEmpty()
                .WithMessage("");

            RuleFor(p => p.NewPassword)
                .NotEmpty()
                .Matches(RegexPatterns.Password)
                .WithMessage("Password must be at least 8 digits  and contain at least one uppercase letter, one lowercase letter, one digit and one special character ")
                .NotEqual(p=>p.CurrentPassword)
                .WithMessage("New Password cannot be same as the current password");

        }
    }
}
