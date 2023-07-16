using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using QuizApp.Application.Common.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static QuizApp.Infrastructure.Common.Constants.Identity;

namespace QuizApp.Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private ApplicationUser _user;

        public IdentityService(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var token = GenerateTokenOptions(claims, signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> RegisterUserAsync(string email, string userName, string password)
        {
            if ((await _userManager.FindByEmailAsync(email) != null) || (await _userManager.FindByNameAsync(userName)) != null)
                return false;

            _user = new ApplicationUser()
            {
                Email = email,
                UserName = userName,
            };

            var rs = await _userManager.CreateAsync(_user, password);

            if (!rs.Succeeded) return false;

            rs = await _userManager.AddToRoleAsync(_user, Role.USER);
            return rs.Succeeded;
        }

        public async Task<bool> ValidateUser(string userAccount, string password)
        {
            _user = await _userManager.FindByEmailAsync(userAccount);
            _user ??= await _userManager.FindByNameAsync(userAccount);
            if (_user is null) return false;

            bool checkUserSuccess = await _userManager.CheckPasswordAsync(_user, password);
            return checkUserSuccess;
        }

        #region private method

        private JwtSecurityToken GenerateTokenOptions(List<Claim> claims, SigningCredentials signingCredentials)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var expiration = DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("lifetime").Value));

            var token = new JwtSecurityToken(
                                            issuer: jwtSettings.GetSection("Issuer").Value,
                                            claims: claims,
                                            expires: expiration,
                                            signingCredentials: signingCredentials);
            return token;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypeUser.USER_NAME, _user.UserName),
                new Claim(ClaimTypeUser.USER_ID, _user.Id),
                new Claim(ClaimTypeUser.NICK_NAME, _user.NickName ?? string.Empty),
                new Claim(ClaimTypeUser.FULL_NAME, _user.FullName ?? string.Empty),
            };

            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypeUser.ROLE, role));
            }

            return claims;
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = _configuration.GetSection("Secret").GetSection("Key").Value;
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var signingCredentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha512Signature);

            return signingCredentials;
        }

        #endregion
    }
}
