using AppraisalTool.Application.Features.Users.Command.CreateUserCommand;
using AppraisalTool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Contracts.Persistence
{
    public interface IUserRepository
    {
        public Task<User> AddUser(User user);
        Task<CreateUserDto> RegisterUserAsync(User request);
        public Task<User> FindUserByEmail(string email);
        public Task<bool> UpdateUser(User user);
    }

}
