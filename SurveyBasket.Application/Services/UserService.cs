using SurveyBasket.Application.Abstractions.DTOs.Users.Request;
using SurveyBasket.Application.Abstractions.DTOs.Users.Response;

namespace SurveyBasket.Application.Services
{
    public class UserService(UserManager<ApplicationUser> userManager) : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;

        public async Task<Result<UserProfileResponse>> GetProfileAsync(string userId)
        {
            var user = await _userManager.Users
                .Where(u => u.Id == userId)
                .ProjectToType<UserProfileResponse>()
                .SingleAsync();

            return Result.Success(user);
        }

        public async Task<Result> UpdateProfileAsync(string userId, UpdateProfileRequest request)
        {
            var user = await _userManager.FindByIdAsync(userId);

            user = request.Adapt(user);
            await _userManager.UpdateAsync(user!);

            return Result.Success();
        }
    }
}
