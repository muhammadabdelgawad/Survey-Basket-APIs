using SurveyBasket.Application.Abstractions.Repositories.Users;

namespace SurveyBasket.Api.Controllers
{
    [Route("me")]
    [ApiController]
    [Authorize]
    public class AccountController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpGet("")]
        public async Task<IActionResult> Info() 
        {
            var userProfile = await _userService.GetProfileAsync(User.GetUserId()!);

            return Ok(userProfile);
        }
    }
}
