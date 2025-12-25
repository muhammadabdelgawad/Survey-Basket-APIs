namespace SurveyBasket.Application.Abstractions.DTOs.Auth.Request
{
    public record RefreshTokenRequest(
        string Token,
        string RefreshToken
        );
}
