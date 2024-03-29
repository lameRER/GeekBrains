using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Timesheets.Service.Authentication;

namespace Timesheets.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromQuery] string user, string password)
        {
            var token = _userService.Authenticate(user, password);
            if (token is null)
            {
                return BadRequest(new {message = "Username or password is incorrect"});
            }
            SetTokenCookie(token.RefreshToken);
            return Ok(token);
        }
        
        [Authorize]
        [HttpPost("refresh-token")]
        public IActionResult Refresh()
        {
            var oldRefreshToken = Request.Cookies["refreshToken"];
            var newRefreshToken = _userService.RefreshToken(oldRefreshToken);

            if (string.IsNullOrWhiteSpace(newRefreshToken))
            {
                return Unauthorized(new { message = "Invalid token" });
            }
            SetTokenCookie(newRefreshToken);	
            return Ok(newRefreshToken);
        }

        private void SetTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };	
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }
    }
}