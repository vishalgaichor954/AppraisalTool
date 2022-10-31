using AppraisalTool.Application.Models.AppraisalTool;
using AppraisalTool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Contracts.Persistence
{
    public interface IAuthenticationService
    {
        public Task<bool> AddUser(User user);
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt);
        public Task<AuthenticationResponse> Login(string email, string password);
        public Task<string> ResetPassword(string email);
        public Task<bool> EmailsDoesNotExists(string email);
        public Task<dynamic> GetCards(int id);
    }
}
