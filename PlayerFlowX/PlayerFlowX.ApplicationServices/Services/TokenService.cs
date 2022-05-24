using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PlayerFlowX.ApplicationServices.AutoMapperSettings;
using PlayerFlowX.ApplicationServices.Interfaces;
using PlayerFlowX.ApplicationServices.Requests.User;
using PlayerFlowX.Domain.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PlayerFlowX.ApplicationServices.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        public readonly SymmetricSecurityKey _key;

        public TokenService(IConfiguration configuration, UserManager<User> userManager)
        {
            this._configuration = configuration;
            this._userManager = userManager;
            this._key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration["TokenKey"]));
        }

        public async Task<string> CreateToken(UserUpdateRequest UserUpdateRequest)
        {
            var user = UserUpdateRequest.MapTo<UserUpdateRequest, User>();

            var claims = GetClaims(user);

            var roles = await _userManager.GetRolesAsync(user);

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokeHandler = new JwtSecurityTokenHandler();

            var token = tokeHandler.CreateToken(tokenDescription);

            return tokeHandler.WriteToken(token);
        }

        private List<Claim> GetClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            return claims;
        }
    }
}
