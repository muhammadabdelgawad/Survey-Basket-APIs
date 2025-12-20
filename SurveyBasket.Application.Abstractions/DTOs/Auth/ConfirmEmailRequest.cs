namespace SurveyBasket.Application.Abstractions.DTOs.Auth
{
    public record ConfirmEmailRequest
    (
        string UserId,
        string Code
    );
}
