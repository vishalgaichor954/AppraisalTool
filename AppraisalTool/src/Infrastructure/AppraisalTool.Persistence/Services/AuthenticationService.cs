using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Models.AppraisalTool;
using AppraisalTool.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<AuthenticationService> _logger;

        public AuthenticationService(IUserRepository userRepository, IConfiguration configuration, ILogger<AuthenticationService> logger)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _logger = logger;
        }

        //@Author : Ilyas Dabholkar
        //Generates random password of specified length using lower/upper case alphabets numbers and symbols.
        public static string GeneratePassword(int passLength)
        {
            var chars = "abcdefghijklmnopqrstuvwxyz@#$&ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, passLength)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }

        //@Author : Ilyas Dabholkar
        public async Task<bool> AddUser(User user)
        {
            try
            {
                await _userRepository.AddUser(user);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //@Author : Ilyas Dabholkar
        public async Task<AuthenticationResponse> Login(string email, string password)
        {
            User user = await _userRepository.FindUserByEmail(email);
            if (user == null)
            {

                throw new Exception("Faild to find user with these credentials");
            }
            else
            {
                if (user.IsDeleted == true)
                {
                    return null;
                }
                else
                {

                    bool isAuthenticated = VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);
                    if (isAuthenticated)
                    {
                        string name = $"{user.FirstName} {user.LastName}";
                        string token = GenerateToken(user.Id, user.Email, user.Role.Role, name);
                        return new AuthenticationResponse() { IsAuthenticated = true, Token = token, Role = user.Role.Role, Message = null, Name = name, RoleId = user.RoleId, UserId = user.Id };
                    }
                    else
                    {
                        return null;
                    }

                }

            }
        }

        //@Author : Ilyas Dabholkar
        //Method for setting claims and JWT Token generation 
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


        //@Author : Ilyas Dabholkar
        //Generates Passwords Hash and Password Salt
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        //@Author : Ilyas Dabholkar
        //Verify Password with Existing Hashed Password
        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }


        //@Author : Ilyas Dabholkar
        //resets password to a new randomly generated password
        public async Task<string> ResetPassword(string email)
        {
            try
            {
                _logger.LogInformation("Reset Password Initiated");
                var user = await _userRepository.FindUserByEmail(email);
                if (user != null)
                {
                    _logger.LogInformation("User Found!Generating new password");
                    string password = GeneratePassword(8);
                    Console.Write($"Password Generated :{password}");
                    _logger.LogInformation("Encrypting GenaratedPassword");
                    CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                    bool userUpdated = await _userRepository.UpdateUser(user);
                    if (userUpdated == true)
                    {
                        _logger.LogInformation("Password Updated Successfully");
                        return password;
                    }
                    return null;
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> EmailsDoesNotExists(string email)
        {
            _logger.LogInformation("Email Does not exists intiated");
            var user = await _userRepository.FindUserByEmail(email);

            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }


        }


        //public async Task<dynamic> GetCards(int id)
        //{

        //    var cards = await _userRepository.getCards(id);

        //    return cards;


        //}
    }
}
