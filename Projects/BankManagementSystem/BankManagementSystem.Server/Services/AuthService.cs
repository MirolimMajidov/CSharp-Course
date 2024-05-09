using BankManagementSystem.Auth;
using BankManagementSystem.Contracts;
using BankManagementSystem.Infrastructure;
using BankManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BankManagementSystem.Services
{
    public class AuthService
    {
        private readonly BankContext _context;
        public AuthService(BankContext context)
        {
            _context = context;
        }

        public async Task<TokenInfo> Login(string username, string password)
        {
            var user = await _context.Persons.SingleOrDefaultAsync(x => x.Username == username && x.Password == password);

            return await GeneratedJWT(user);
        }

        public async Task<TokenInfo> RefreshToken(string refreshToken)
        {
            var user = await _context.Persons.SingleOrDefaultAsync(x => x.RefreshToken == refreshToken);

            return await GeneratedJWT(user);
        }

        async Task<TokenInfo> GeneratedJWT(Person user)
        {
            if (user is null)
                throw new ArgumentException("Invalid username or password.");

            if (user.IsBlocked)
                throw new ArgumentException("User does not have access to login.");

            var userRoles = new string[] { user.Role };

            var claims = new List<Claim> {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FullName)
            };

            foreach (var userRole in userRoles)
                claims.Add(new Claim(ClaimTypes.Role, userRole));

            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);
            var refreshToken = Guid.NewGuid().ToString();

            user.RefreshToken = refreshToken;
            _context.Update(user);
            await _context.SaveChangesAsync();

            return new TokenInfo { AccessToken = accessToken, RefreshToken = refreshToken };
        }
    }
}
