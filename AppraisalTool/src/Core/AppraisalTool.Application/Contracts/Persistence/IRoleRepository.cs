using AppraisalTool.Application.Features.UserJobProfileRoles.Command.CreateJobProfileRoleCommand;
using AppraisalTool.Application.Features.UserJobProfileRoles.Command.RemoveJobProfileRoleCommand;
using AppraisalTool.Application.Features.UserJobProfileRoles.Command.UpdateJobProfileRoleCommand;
using AppraisalTool.Application.Features.UserRoles.Command.CreateUserRoleCommand;
using AppraisalTool.Application.Features.UserRoles.Command.RemoveUserRoleCommand;
using AppraisalTool.Application.Features.UserRoles.Command.UpdateUserRoleCommand;
using AppraisalTool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Contracts.Persistence
{
    public interface IRoleRepository
    {
        public Task<IEnumerable<JobRoles>> GetAllJobRoles();
        public Task<bool> AddJobRoles(List<UserJobRoles> userJobRoles);
        public Task<RemoveUserRoleCommandDto>  RemoveUserRole(int id);
        public Task<CreateJobProfileCommandDto> AddJobProfileRole(JobRoles result);
        public Task<UpdateJobProfileCommandDto> UpdatejobProfileRole(UpdateJobProfileCommand request, int id);
      
        public Task<RemoveJobProfileCommandDto> RemoveJobProfileRole(int id);
        public Task<JobRoles> GetJobProfileById(int id);
        
    }

}
