using SurveyBasket.Application.Abstractions.Repositories.Roles;

namespace SurveyBasket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController(IRoleService roleService) : ControllerBase
    {
        private readonly IRoleService _roleService = roleService;

        [HttpGet("")]
        [HasPermission(Permissions.ReadRoles)]
        public async Task<IActionResult> GetAll([FromQuery] bool? includeDisabled,CancellationToken cancellationToken)
        {
            var roles = await _roleService.GetAllRolesAsync(includeDisabled,cancellationToken);
            return Ok(roles);
        }

    }
}
