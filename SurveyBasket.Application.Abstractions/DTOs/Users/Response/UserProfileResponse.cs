namespace SurveyBasket.Application.Abstractions.DTOs.Users.Response
{
    public record UserProfileResponse(
    
        string Email,
        string UserName,
        string FirstName,
        string LastName
    );
}
