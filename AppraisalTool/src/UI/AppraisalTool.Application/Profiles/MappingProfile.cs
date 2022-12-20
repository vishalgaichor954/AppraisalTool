using AppraisalTool.App.Dtos;
using AppraisalTool.App.Models;
using AppraisalTool.App.Models.Branches;
using AppraisalTool.App.Models.JobRoles;
using AppraisalTool.App.Models.UserRole;
using AutoMapper;

namespace AppraisalTool.App.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserViewModel, UserEncodeDto>().ConvertUsing<EncodeUserListVm>();
            CreateMap<JobRoles, jobRolesEncoded>().ConvertUsing<EncodedJobRolesList>();
            CreateMap<UserRole, UserEncodedDto>().ConvertUsing<EncodedRoleLists>();
            CreateMap<BranchVm, EncodedBranchDto>().ConvertUsing<EncodedBranchList>();
            CreateMap<AssignAuthorityVm, EncodedAssignAuthorityDTo>().ConvertUsing<EncodedAssignAuthority>();
        }
    }
}

