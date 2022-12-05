using AppraisalTool.Application.Features.UserRoles.Command.CreateUserRoleCommand;
using AppraisalTool.Application.Features.UserRoles.Command.UpdateUserRoleCommand;
using AppraisalTool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Contracts.Persistence
{
    public interface IUserRoleRepository
    {
        public Task<IEnumerable<UserRole>> GetAllRole();

        public Task<CreateUserRolesCommandDto> CreateUserRole(UserRole res);

        public Task<UpdateUserRolesCommandDto> UpdateUserRole(UpdateUserRolesCommand request, int id);
        public Task<UserRole> GetUserRoleById(int id);
    }
}
