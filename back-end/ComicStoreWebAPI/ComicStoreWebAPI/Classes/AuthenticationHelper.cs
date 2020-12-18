using ComicStore.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ComicStore.Application.Classes
{
    public class AuthenticationHelper
    {

        private readonly UserManager<IdentityUser> userManager;
        private readonly IConfiguration configuration;
        private readonly ICustomerService customerService;

        public AuthenticationHelper(
            UserManager<IdentityUser> userManager,
            IConfiguration configuration,
            ICustomerService customerService)
        {
            this.userManager = userManager;
            this.configuration = configuration;
            this.customerService = customerService;
        }

        public async Task<string> GenerateJwtToken(string email)
        {
            IdentityUser user = await userManager.FindByEmailAsync(email);
            IList<string> userRoles = await userManager.GetRolesAsync(user);
            string customerID = customerService.GetCustomerByUserID(user.Id)?.CustomerID
                                               .ToString();



            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim("userID",user.Id),
            };

            if (customerID != null)
            {
                Claim customerIDClaim = new Claim("customerID", customerID);
                claims.Add(customerIDClaim);
            }

            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["ApplicationSettings:JWT_Secret"].ToString());
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
