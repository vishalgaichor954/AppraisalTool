using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Models.AppraisalTool;
using AppraisalTool.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace AppraisalTool.Persistence.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthenticationService(IUserRepository userRepository,IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<bool> AddUser(User user)
        {
            try
            {
                await _userRepository.AddUser(user);
                return true;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<AuthenticationResponse> Login(string email,string password)
        {
            User user = await _userRepository.FindUserByEmail(email);
            if (user == null)
            {

                throw new Exception("Faild to find user with these credentials");
            }
            else
            {
                bool isAuthenticated = VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);
                if (isAuthenticated)
                {
                    string name = $"{user.FirstName} {user.LastName}";
                    string token = GenerateToken(user.Id, user.Email, user.Role.Role, name);
                    return new AuthenticationResponse() { IsAuthenticated = true, Token = token, Role = user.Role.Role,Message=null};
                }
                else
                {
                    return null;
                }
            }
        }

        public string GenerateToken(int id, string email, string role, string name)
        {
            var payload = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Jti,id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email,email),
                new Claim(JwtRegisteredClaimNames.GivenName,name),
                new Claim(ClaimTypes.Role,role)
            };

            string JwtSecret = _configuration.GetValue<string>("JwtSettings:Key");
            string JwtIssuer = _configuration.GetValue<string>("JwtSettings:Issuer");
            var JwtAudiance = _configuration.GetValue<string>("JwtSettings:Audience");
            var JwtValidity = _configuration.GetValue<string>("JwtSettings:DurationInMinutes");

            var symmetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSecret));

            var jwtToken = new JwtSecurityToken(
                issuer: JwtIssuer,
                audience: JwtAudiance,
                claims: payload,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(JwtValidity)),
                signingCredentials: new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256)
            );
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return jwtSecurityTokenHandler;
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
             using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
