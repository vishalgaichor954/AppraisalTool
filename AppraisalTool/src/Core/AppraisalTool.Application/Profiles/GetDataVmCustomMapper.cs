using AppraisalTool.Application.Features.SelfAppraisal.Queries.GetData;
using AppraisalTool.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Profiles
{
    public class GetDataVmCustomMapper : ITypeConverter<Appraisal, GetDataVM>
    {
        

        public GetDataVmCustomMapper()
        {
            
        }
        
            //    EventId = _protector.Protect(source.EventId.ToString()),
            //    Name = source.Name,
            //    ImageUrl = source.ImageUrl,
            //    Date = source.Date
            //};

            //return dest;

        

        public GetDataVM Convert(Appraisal source, GetDataVM destination, ResolutionContext context)
        {
            GetDataVM dest = new GetDataVM()
            {
                Id = source.Id,
                StartDate = source.StartDate,
                EndDate = source.EndDate,
                StatusId = source.StatusId,
                ReviewedOn = source.ReviewedOn,
                ApprovedOn = source.ApprovedOn,
                StartYear=source.FinancialYear.StartYear,
                EndYear =source.FinancialYear.EndYear,
                FinancialYearId= source.FinancialYearId,
                Role = source.User.Role.Role,
    };
            return dest;
        }
    }
}
