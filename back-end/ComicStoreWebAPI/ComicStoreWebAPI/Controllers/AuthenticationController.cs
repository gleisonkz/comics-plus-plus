using ComicStore.Application.Classes;
using ComicStore.Application.DTO;
using ComicStore.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Transactions;

namespace ComicStore.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ComicStoreBaseController
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly AuthenticationHelper authHelper;
        private readonly ICustomerService customerService;


        public AuthenticationController(
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ICustomerService customerService,
            AuthenticationHelper authHelper)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.authHelper = authHelper;
            this.customerService = customerService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO registerUser)
        {
            try
            {
                using (TransactionScope transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    IdentityUser user = registerUser;

                    var resultUser = await userManager.CreateAsync(user, registerUser.Password);
                    if (!resultUser.Succeeded) return BadRequest(resultUser.Errors);

                    await CheckRoleExists("User");

                    var resultRole = await userManager.AddToRoleAsync(user, "User");

                    customerService.CreateCustomer(user.Id);
                    customerService.Commit();
                    transaction.Complete();
                    return Ok();
                };
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        private async Task CheckRoleExists(string roleName)
        {
            bool roleExists = await roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                var role = new IdentityRole
                {
                    Name = roleName
                };
                await roleManager.CreateAsync(role);
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



