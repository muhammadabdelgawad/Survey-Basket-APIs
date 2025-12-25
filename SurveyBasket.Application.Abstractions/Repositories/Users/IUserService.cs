using SurveyBasket.Application.Abstractions.DTOs.Users.Request;
using SurveyBasket.Application.Abstractions.DTOs.Users.Response;
namespace SurveyBasket.Application.Abstractions.Repositories.Users
{
    public interface IUserService
    {
        Task<Result<UserProfileResponse>> GetProfileAsync(string userId);
        Task<Abstractions.Result> UpdateProfileAsync(string userId, UpdateProfileRequest request);
        Task<Abstractions.Result> ChangePasswordAsync(string userId,ChangePasswordRequest request);
    }
}
