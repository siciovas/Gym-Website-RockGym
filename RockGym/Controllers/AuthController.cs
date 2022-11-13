﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RockGym.Jwt;
using RockGym.Models.Auth;

namespace RockGym.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IJwtTokenService _jwtTokenService;

        public AuthController(UserManager<User> userManager, IJwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
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

            return Ok(new SuccessfulLogin(accessToken));
        }

    }
}
