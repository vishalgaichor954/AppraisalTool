using AppraisalTool.App.Dtos;
using AppraisalTool.App.Models.FinancialYear;
using AppraisalTool.App.Models.Menu;
using AutoMapper;
using Microsoft.AspNetCore.DataProtection;

namespace AppraisalTool.App.Profiles
{
    public class EncodeFinancialYearListVm : ITypeConverter<FinancialYear, FinancialYearEncodeDto>
    {

        private readonly IDataProtector _protector;

        public EncodeFinancialYearListVm(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("");
        }

        public FinancialYearEncodeDto Convert(FinancialYear source, FinancialYearEncodeDto destination, ResolutionContext context)
        {
            FinancialYearEncodeDto dest = new FinancialYearEncodeDto()
            {
                Id = _protector.Protect(source.Id.ToString()),
                StartYear = source.StartYear,
                EndYear = source.EndYear,
                StartDate = source.StartDate,
                EndDate = source.EndDate,
                AddedBy = source.AddedBy,
                UpdatedBy = source.UpdatedBy,
                IsActive = source.IsActive
            };

            return dest;
        }
    }
}
