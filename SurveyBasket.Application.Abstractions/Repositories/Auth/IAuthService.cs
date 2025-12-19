using SurveyBasket.Application.Abstractions.DTOs.Auth;
namespace SurveyBasket.Application.Abstractions.Repositories.Auth
{
    public interface IAuthService
    {
        Task<Result<AuthResponse>> GetTokenAsync(string email, string password,
            CancellationToken cancellationToken = default);
        Task<Result<AuthResponse>> GetRefreshTokenAsync(string token, string refreshToken,
          CancellationToken cancellationToken = default);
        Task<Abstractions.Result> RevokeRefreshTokenAsync(string token, string refreshToken, CancellationToken cancellationToken = default);
        public Task<Result<AuthResponse>> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default);
    }
}
