namespace SurveyBasket.Application.Abstractions.DTOs.Auth.Request
{
    public record LoginRequest(

        string Email,
        string Password
    );
}
