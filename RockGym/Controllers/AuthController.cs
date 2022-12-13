using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RockGym.Jwt;
using RockGym.Models.Auth;
using RockGym.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RockGym.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly ISubscriptionRepository _subscriptions;

        public AuthController(UserManager<User> userManager, IJwtTokenService jwtTokenService, ISubscriptionRepository subscriptions)
        {
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
            _subscriptions = subscriptions;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterUser registerUser)
        {
            var user = await _userManager.FindByEmailAsync(registerUser.Email);
            if (user != null)
            {
                return BadRequest("Invalid");
            }

            var newUser = new User
            {
                Email = registerUser.Email,
                UserName = registerUser.Email
            };

            var createUserResult = await _userManager.CreateAsync(newUser, registerUser.Password);
            if (!createUserResult.Succeeded)
            {
                return BadRequest("Invalid");
            }

            await _userManager.AddToRoleAsync(newUser, Roles.RegisteredUser);
            return CreatedAtAction(nameof(Register), new UserDto(newUser.Id, newUser.Email));
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(LoginUser loginUser)
        {
            var user = await _userManager.FindByNameAsync(loginUser.Email);
            if (user == null)
            {
                return BadRequest("Invalid");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginUser.Password);
            if (!isPasswordValid)
            {
                return BadRequest("Invalid");
            }

            var roles = await _userManager.GetRolesAsync(user);
            var accessToken = _jwtTokenService.CreateAccessToken(user.Email, user.Id.ToString(), roles);
            var subscription = _subscriptions.GetByUserId(user.Id.ToString());

            if (subscription == null)
            {
                return Ok(new SuccessfulLogin(accessToken));
            }

            return Ok(new SuccessfulLogin(accessToken, subscription.Id));
        }

        [HttpGet]
        [Route("roles")]
        public async Task<ActionResult> GetRoles()
        {
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);
            var user = await _userManager.FindByIdAsync(userId);

            var userRoles = await _userManager.GetRolesAsync(user);
            return Ok(userRoles);
        }

    }
}
