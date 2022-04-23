using EntityModel.Context;
using EntityModel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FFStudioServices.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class AuthenTokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly PostgreContext _context;

        public AuthenTokenController(IConfiguration config, PostgreContext context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Post(Account _accountData)
        {
            if (_accountData != null && _accountData.Username != null & _accountData.Password != null)
            {
                var user = await GetUser(_accountData.Username, _accountData.Password);
                {
                    if (user != null)
                    {
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt: Subject"]),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                            new Claim("UserId", user.UserId),
                            new Claim("Username", user.Username)
                        };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            _configuration["Jwt:Issuer"],
                            _configuration["Jwt:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddMinutes(10),
                            signingCredentials: signIn
                            );
                        return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                    }
                    else
                    {
                        return BadRequest("Invalid credentials");
                    };
                };
            }
            else
            {
                return BadRequest();
            };
        }

        private async Task<Account> GetUser(string? username, string? password)
            => await _context.Accounts.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
    }
}
