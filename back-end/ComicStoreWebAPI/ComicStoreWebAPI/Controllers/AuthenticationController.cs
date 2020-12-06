using ComicStore.Application.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ComicStore.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration Configuration;

        public AuthenticationController(IConfiguration configuration, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.Configuration = configuration;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO registerUser)
        {
            try
            {
                var user = new IdentityUser
                {
                    UserName = registerUser.Email,
                    Email = registerUser.Email,
                    EmailConfirmed = true
                };

                var resultUser = await userManager.CreateAsync(user, registerUser.Password);
                if (!resultUser.Succeeded) return BadRequest(resultUser.Errors);

                bool roleExists = await roleManager.RoleExistsAsync("User");
                if (!roleExists)
                {
                    var role = new IdentityRole
                    {
                        Name = "User"
                    };
                    await roleManager.CreateAsync(role);
                }               

                var resultRole = await userManager.AddToRoleAsync(user, "User");

                await signInManager.SignInAsync(user, false);
                return Ok("Usuario Criado");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO loginUser)
        {
            var result = await signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);
            if (result.Succeeded) return Ok(await GenerateJwtToken(loginUser.Email));
            return BadRequest("Usuário ou senha inválidos");
        }

        public async Task<string> GenerateJwtToken(string email)
        {
            IdentityUser user = await userManager.FindByEmailAsync(email);
            var userRoles = await userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };
            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}



