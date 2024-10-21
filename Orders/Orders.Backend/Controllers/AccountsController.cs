using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Orders.Backend.UnitOfWork.Interfaces;
using Orders.Shared.DTOs;
using Orders.Shared.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Orders.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly IUsersUnitOfWoks _usersUnitOfWoks;
        private readonly IConfiguration _configuration;

        public AccountsController(IUsersUnitOfWoks usersUnitOfWoks, IConfiguration configuration)
        {
            _usersUnitOfWoks = usersUnitOfWoks;
            _configuration = configuration;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO model)
        {
            User user = model;
            var result = await _usersUnitOfWoks.AddUserAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _usersUnitOfWoks.AddUserToRolAsync(user, user.UsertType.ToString());
                return Ok(BuildToken(user));
            }

            return BadRequest(result.Errors.FirstOrDefault());
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDTO model)
        {
            var result = await _usersUnitOfWoks.LoginAsync(model);
            if (result.Succeeded)
            {
                var user = await _usersUnitOfWoks.GetUserAsync(model.Email);
                return Ok(BuildToken(user));
            }

            return BadRequest("Email o contraseña incorrectos.");
        }

        private TokenDTO BuildToken(User user)
        {
            var claims = new List<Claim>
            {
                new (ClaimTypes.Name, user.Email!),
                new (ClaimTypes.Role, user.UsertType.ToString()),
                new ("Document", user.Document),
                new ("FirstName", user.FirstName),
                new ("LastName", user.LastName),
                new ("Address", user.Address),
                new ("Photo", user.Photo ?? string.Empty),
                new ("CityId", user.CityId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwtKey"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddDays(30);
            var token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiration,
                signingCredentials: credentials);

            return new TokenDTO
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}