using SurveyBasket.Application.Abstractions.DTOs.Auth.Request;

namespace SurveyBasket.Application.Validations.Auth
{
    public class ResendConfirmationEmailRequestValidator : AbstractValidator<ResendConfirmationEmailRequest>
    {
        public ResendConfirmationEmailRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
