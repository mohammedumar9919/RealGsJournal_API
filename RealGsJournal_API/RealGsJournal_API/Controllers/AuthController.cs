using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealGsJournal_API.Dtos;
using RealGsJournal_API.Interfaces.User;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;


namespace RealGsJournal_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthProvider _authProvider;
        private readonly IUserProvider _userProvider;

        public AuthController(IAuthProvider authProvider, IUserProvider userProvider)
        {
            _authProvider = authProvider;
            _userProvider = userProvider;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var token = await _authProvider.LoginAsync(dto);
            if (token == null)
                return Unauthorized(new { message = "Invalid credentials" });

            return Ok(new { token });
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> Me()
        {
            // Try sub first
            var userId = User.FindFirstValue(JwtRegisteredClaimNames.Sub);

            // Fallback to NameIdentifier
            if (userId == null)
                userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userId == null)
                return Unauthorized();

            var user = await _userProvider.GetUserByIdAsync(int.Parse(userId));
            if (user == null)
                return Unauthorized();

            return Ok(user);
        }

        [HttpGet("debug")]
        public IActionResult DebugAuthHeader([FromHeader(Name = "Authorization")] string auth)
        {
            if (string.IsNullOrWhiteSpace(auth))
                return Ok("NO AUTH HEADER RECEIVED");

            return Ok("AUTH HEADER RECEIVED: " + auth);
        }

    }
}

