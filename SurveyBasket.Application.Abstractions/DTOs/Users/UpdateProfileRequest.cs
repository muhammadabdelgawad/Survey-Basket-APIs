namespace SurveyBasket.Application.Abstractions.DTOs.Users
{
    public record UpdateProfileRequest
    (
        string FirstName,
        string LastName
    );
}
