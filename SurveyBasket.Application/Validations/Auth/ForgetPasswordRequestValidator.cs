namespace SurveyBasket.Application.Validations.Auth
{
    public class ForgetPasswordRequestValidator : AbstractValidator<ForgetPasswordRequest>
    {
        public ForgetPasswordRequestValidator()
        {
            RuleFor(p => p.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
