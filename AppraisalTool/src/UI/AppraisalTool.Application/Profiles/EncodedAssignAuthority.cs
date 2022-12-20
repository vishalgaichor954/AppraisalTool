using AppraisalTool.App.Models;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;

namespace AppraisalTool.App.Profiles
{
    public class EncodedAssignAuthority : ITypeConverter<AssignAuthorityVm, EncodedAssignAuthorityDTo>
    {
        private readonly IDataProtector _protector;

        public EncodedAssignAuthority(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("");
        }
        public EncodedAssignAuthorityDTo Convert(AssignAuthorityVm source, EncodedAssignAuthorityDTo destination, ResolutionContext context)
        {
            EncodedAssignAuthorityDTo dto = new EncodedAssignAuthorityDTo()
            {
                Id = _protector.Protect(source.Id.ToString()),
                Name=source.Name,
                RepaId=source.RepaId,
                RevaId=source.RevaId,   

            };

            return dto;
        }
    }
}
