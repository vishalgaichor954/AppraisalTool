using AppraisalTool.App.Models.UserRole;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;

namespace AppraisalTool.App.Profiles
{
    public class EncodedRoleLists : ITypeConverter<UserRole, UserEncodedDto>
    {
        private readonly IDataProtector _protector;

        public EncodedRoleLists(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("");
        }
        public UserEncodedDto Convert(UserRole source, UserEncodedDto destination, ResolutionContext context)
        {
            UserEncodedDto dtos = new UserEncodedDto()
            {
                Id= _protector.Protect(source.Id.ToString()),
                Role =source.Role,
                AddedBy=source.AddedBy,
                UpdatedBy=source.UpdatedBy,
            };
            return dtos;
        }
    }
}
