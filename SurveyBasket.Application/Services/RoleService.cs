using SurveyBasket.Application.Abstractions.DTOs.Roles;
using SurveyBasket.Application.Abstractions.Repositories.Roles;

namespace SurveyBasket.Application.Services
{
    public class RoleService(RoleManager<ApplicationRole> roleManager) : IRoleService
    {
        private readonly RoleManager<ApplicationRole> _roleManager = roleManager;

        public async Task<IEnumerable<RoleResponse>> GetAllRolesAsync(bool? includeDisabled = false,CancellationToken cancellationToken = default)
        {
            return await _roleManager.Roles
                .Where(r => !r.IsDefault && (!r.IsDeleted || (includeDisabled.HasValue && includeDisabled.Value))) // => (includeDisabled.HasValue && includeDisabled.Value) is equivalent to ( includeDisabled == true )
                .ProjectToType<RoleResponse>()
                .ToListAsync(cancellationToken);
        }

        public async Task<Result<RoleDetailResponse>> GetRoleByIdAsync(string id, CancellationToken cancellationToken= default) 
        {
            if(await _roleManager.FindByIdAsync(id) is not { } role) 
               return Result.Failure<RoleDetailResponse>(RoleErrors.RoleNotFound);
            
            var permissions = await _roleManager.GetClaimsAsync(role);

            var response = new RoleDetailResponse(role.Id, role.Name!, role.IsDeleted, permissions.Select(p => p.Value));

            return Result.Success(response);
        }
    }
}
