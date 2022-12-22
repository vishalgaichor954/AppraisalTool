using AppraisalTool.App.Models.Branches;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;

namespace AppraisalTool.App.Profiles
{
    public class EncodedBranchList : ITypeConverter<BranchVm, EncodedBranchDto>
    {
        private readonly IDataProtector _protector;

        public EncodedBranchList(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("");
        }
        public EncodedBranchDto Convert(BranchVm source, EncodedBranchDto destination, ResolutionContext context)
        {

            EncodedBranchDto dto = new EncodedBranchDto()
            {
                Id = _protector.Protect(source.Id.ToString()),
                BranchName = source.BranchName,
                BranchCode = source.BranchCode,
                AddedBy = source.AddedBy,
                UpdatedBy=source.UpdatedBy,

            };

            return dto;
        }
    }
}
