using SurveyBasket.Application.Abstractions.DTOs.Users;
namespace SurveyBasket.Application.Abstractions.Repositories.Users
{
    public interface IUserService
    {
        Task<Result<UserProfileResponse>> GetProfileAsync(string userId);
    }
}
