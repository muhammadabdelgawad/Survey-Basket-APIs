using SurveyBasket.Application.Abstractions.DTOs.Users.Request;
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

        [HttpPut("info")]
        public async Task<IActionResult> Info([FromBody] UpdateProfileRequest request)
        {
            await _userService.UpdateProfileAsync(User.GetUserId()!, request);
            return NoContent();
        }
    }
}
