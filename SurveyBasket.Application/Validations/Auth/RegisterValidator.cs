using SurveyBasket.Application.Abstractions.Abstractions.Const;

namespace SurveyBasket.Application.Validations.Auth
{
    public class RegisterValidator: AbstractValidator<RegisterRequest>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty()
                .Matches(RegexPatterns.Password)
                .WithMessage("Password must be at least 8 digits  and contain at least one uppercase letter, one lowercase letter, one digit and one special character ");

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .Length(3,100);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .Length(3, 100);

        }

    }
}
