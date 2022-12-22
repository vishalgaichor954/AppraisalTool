using AppraisalTool.App.Models.JobRoles;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;

namespace AppraisalTool.App.Profiles
{
    public class EncodedJobRolesList : ITypeConverter<JobRoles, jobRolesEncoded>
    {
        private readonly IDataProtector _protector;

        public EncodedJobRolesList(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("");
        }

        public jobRolesEncoded Convert(JobRoles source, jobRolesEncoded destination, ResolutionContext context)
        {
            jobRolesEncoded dest = new jobRolesEncoded()
            {
                Id = _protector.Protect(source.Id.ToString()),
                Name=source.Name,
                AddedBy=source.AddedBy,
                UpdatedBy=source.UpdatedBy,
           

            };

            return dest;

        }
    }
}
