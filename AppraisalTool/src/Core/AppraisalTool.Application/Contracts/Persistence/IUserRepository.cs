﻿using AppraisalTool.Application.Features.Appraisals.Query.GetAppraisalList;
using AppraisalTool.Application.Features.Authority.Query.GetAllAuthority;
using AppraisalTool.Application.Features.Users.Command.AssignAuthorityCommand;
using AppraisalTool.Application.Features.Users.Command.CreateRoleCommand;
using AppraisalTool.Application.Features.Users.Command.CreateUserCommand;
using AppraisalTool.Application.Features.Users.Command.RemoveUserCommand;
using AppraisalTool.Application.Features.Users.Command.UpdateUserCommand;
using AppraisalTool.Application.Features.Users.Query.GetUserList;
using AppraisalTool.Application.Models.AppraisalTool;
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
        public Task<bool> AssignAuthority(int repaId, int revaId, int userId);
        public Task<User> FindUserByEmail(string email);
        Task<RemoveUserCommandDto> RemoveUserAsync(int id);
        Task<UpdateUserCommandDto> UpdateUserAsync(int id, UpdateUserCommand request);
        Task<IEnumerable<User>> GetUserByRoleId(int roleId);
        public Task<bool> UpdateUser(User user);
        public Task<IEnumerable<GetAppraisalDto>> GetAllAppraisals();
        public Task<IEnumerable<GetAllAuthorityQueryVm>> GetAllUserList();
        public Task<IEnumerable<User>> GetAllUser();
        Task<CreateRoleCommandDto> CreateUserRole(UserJobRoles request);

        //public Task<dynamic> getCards(int id);
        public Task<User> GetUserById(int id);
        //public Task<IQueryable<GetUserListQueryVm>> Getuserbyid(int id);
        public Task<List<MenuRoleMapping>> getAllCards(int id);
        public Task<bool> AllowEdit(AppraisalForEditVm appraisalForEditVm);
        public Task<bool> RequestEdit(AppraisalForEditVm appraisalForEditVm);
        public Task<bool> RequestToEdit(int? fId, int? userId);

        public Task<AssignAuthorityCommandDto> AssignAuthority(int id, AssignAuthorityCommand request);
        public Task<GetUserListQueryVm> GetUserbyid(int id);
        public Task<Appraisal> GetAppraisalByFidAndUserId(int? fId, int? userId);
    }

}
