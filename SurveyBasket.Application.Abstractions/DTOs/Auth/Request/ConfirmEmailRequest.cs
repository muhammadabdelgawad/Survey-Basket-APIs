namespace SurveyBasket.Application.Abstractions.DTOs.Auth.Request
{
    public record ConfirmEmailRequest
    (
        string UserId,
        string Code
    );
}
