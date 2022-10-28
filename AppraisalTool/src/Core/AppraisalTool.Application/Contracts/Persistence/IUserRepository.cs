﻿using AppraisalTool.Application.Features.Users.Command.CreateUserCommand;
using AppraisalTool.Application.Features.Users.Command.RemoveUserCommand;
using AppraisalTool.Application.Features.Users.Command.UpdateUserCommand;
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
        Task<RemoveUserCommandDto> RemoveUserAsync(int id);
        Task<UpdateUserCommandDto> UpdateUserAsync(int id, UpdateUserCommand request);
        public Task<bool> UpdateUser(User user);
        public Task<dynamic> getCards(int id);
    }

}
