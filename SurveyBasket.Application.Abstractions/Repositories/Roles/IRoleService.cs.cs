using SurveyBasket.Application.Abstractions.DTOs.Roles;

namespace SurveyBasket.Application.Abstractions.Repositories.Roles
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleResponse>> GetAllRolesAsync(bool? includeDisabled = false, CancellationToken cancellationToken= default);
    }
}
