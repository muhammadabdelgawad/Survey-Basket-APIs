namespace SurveyBasket.Application.Abstractions.DTOs.Auth
{
    public record RegisterRequest
    (
        string Email,
        string Password,
        string FirstName,
        string LastName
    );
}
