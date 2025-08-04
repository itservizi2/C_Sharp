using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            // Challenge the Google scheme. After success, the framework will sign into the Cookie scheme.
            var properties = new AuthenticationProperties { RedirectUri = Url.Action(nameof(GoogleResponse)) };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [HttpGet("google-response")]
        public async Task<IActionResult> GoogleResponse()
        {
            // The user is now authenticated via the temporary cookie.
            // We get their identity by authenticating against the cookie scheme.
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            if (result?.Succeeded != true)
            {
                return BadRequest("Error authenticating with Google.");
            }

            var claims = result.Principal.Claims;

            // Optional: Find or create user in your DB here using the claims.
            // var userEmail = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            // Create your own stateless JWT
            var jwtKeyString = _configuration["Authentication:Jwt:Key"];
            var issuer = _configuration["Authentication:Jwt:Issuer"];
            var audience = _configuration["Authentication:Jwt:Audience"];

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKeyString));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(8),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(jwtToken);

            // CRITICAL CLEANUP: Sign out of the temporary cookie scheme to make it stateless.
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Return your own JWT to the client
            return Ok(new { token = tokenString });
        }
    }
}