using AppraisalTool.App.Dtos;
using AppraisalTool.App.Models;
using AppraisalTool.Application.Features.Users.Query.GetUserList;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;

namespace AppraisalTool.App.Profiles
{
    public class EncodeUserListVm : ITypeConverter<UserViewModel, UserEncodeDto>
    {
        private readonly IDataProtector _protector;

        public EncodeUserListVm(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("");
        }

        UserEncodeDto ITypeConverter<UserViewModel, UserEncodeDto>.Convert(UserViewModel source, UserEncodeDto destination, ResolutionContext context)
        {
            UserEncodeDto dest = new UserEncodeDto()
            {
                Id = _protector.Protect(source.Id.ToString()),

                FirstName = source.FirstName,
                LastName = source.LastName,
                Email = source.Email,
                Password = source.Password,
                JoinDate = source.JoinDate,
                LastAppraisalDate = source.LastAppraisalDate,
                PrimaryRole = source.PrimaryRole,
                SecondaryRole = source.SecondaryRole,
                RoleId = source.RoleId,
                BranchId = source.BranchId,
                RepaId = source.RepaId,
                RevaId = source.RevaId,
                BranchName = source.BranchName,
                AddedBy = source.AddedBy,
                Role = source.RoleId,
                RoleName = source.RoleName,
                PrimaryJobProfileName = source.PrimaryJobProfileName,
                SecondaryJobProfileName = source.SecondaryJobProfileName,
                SecondaryJobProfileId = source.SecondaryJobProfileId,
                PrimaryJobProfileId = source.PrimaryJobProfileId,
                RevaName = source.RevaName,
                RepaName = source.RepaName

            };

            return dest;
        }
    }
}
