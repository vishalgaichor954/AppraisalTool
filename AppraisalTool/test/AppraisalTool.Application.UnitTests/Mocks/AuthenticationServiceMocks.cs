
using AppraisalTool.Application.Contracts.Persistence;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.UnitTests.Mocks
{
    public class AuthenticationServiceMocks
    {
        public static Mock<IAuthenticationService> Authservice()
        {
            var mockauthRepository = new Mock<IAuthenticationService>();
            //var password = "test"; 
            //out byte[] passwordHash;
            //out byte[] passwordSalt;
            //using (var hmac = new HMACSHA512())
            //{
            //    passwordSalt = hmac.Key;
            //    passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            //}
            //mockauthRepository.Setup(repo => repo.CreatePasswordHash("pass@123"));
            return mockauthRepository;

        }
    }
}
