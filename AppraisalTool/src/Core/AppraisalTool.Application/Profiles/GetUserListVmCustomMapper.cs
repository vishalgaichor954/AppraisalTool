using AppraisalTool.Application.Features.SelfAppraisal.Queries.GetData;
using AppraisalTool.Application.Features.Users.Query.GetUserList;
using AppraisalTool.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Profiles
{
    public class GetUserListVmCustomMapper : ITypeConverter<User, GetUserListQueryVm>
    {

        public GetUserListVmCustomMapper()
        {

        }

        public GetUserListQueryVm Convert(User source, GetUserListQueryVm destination, ResolutionContext context)
        {
            string primaryRole = "";
            string secondaryRole = "";
            int primaryRoleId = 0;
            int secondaryRoleId = 0;

            foreach (UserJobRoles item in source.JobRoles){
                if (item.IsPrimary)
                {
                    primaryRole = item.JobRole.Name;
                    primaryRoleId = item.JobRole.Id;

                }else if (item.IsSecondary)
                {
                    secondaryRole = item.JobRole.Name;
                    secondaryRoleId = item.JobRole.Id;
                }
            }

            GetUserListQueryVm dest = new GetUserListQueryVm()
            {


                Id = source.Id,
                FirstName = source.FirstName,
                LastName = source.LastName,
                Email = source.Email,
                BranchId = source.BranchId,
                BranchName = source.Branch.BranchName,
                JoinDate = source.JoinDate,
                LastAppraisalDate = source.LastAppraisalDate,
                Role = source.RoleId,
                RoleName = source.Role.Role,
                PrimaryJobProfileId = primaryRoleId,
                PrimaryJobProfileName = primaryRole,
                SecondaryJobProfileId = secondaryRoleId,
                SecondaryJobProfileName = secondaryRole
                //RepaId=source.Id,
                //RevaId=source.Id

            };
            return dest;

        }
    }
}
