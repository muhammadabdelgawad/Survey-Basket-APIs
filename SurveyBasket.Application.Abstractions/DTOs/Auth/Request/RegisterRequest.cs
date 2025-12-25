namespace SurveyBasket.Application.Abstractions.DTOs.Auth.Request
{
    public record RegisterRequest
    (
        string Email,
        string Password,
        string FirstName,
        string LastName
    );
}
