namespace SurveyBasket.Application.Abstractions.DTOs.Users.Request
{
    public record ChangePasswordRequest
    (
        string CurrentPassword,
        string NewPassword
    );
}
