namespace SurveyBasket.Application.Abstractions.DTOs.Users
{
    public record UserProfileResponse(
    
        string Email,
        string UserName,
        string FirstName,
        string LastName
    );
}
