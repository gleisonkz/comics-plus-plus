using ComicStore.Application.Classes;
using ComicStore.Application.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
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
        private readonly AuthenticationHelper authHelper;

        public AuthenticationController(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            AuthenticationHelper authHelper)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.authHelper = authHelper;
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
            if (result.Succeeded)
            {
                string token = await authHelper.GenerateJwtToken(loginUser.Email);
                return Ok(new { Token = token });
            }
            return BadRequest("Usuário ou senha inválidos");
        }
    }
}



