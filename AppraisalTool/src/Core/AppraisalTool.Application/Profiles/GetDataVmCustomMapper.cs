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
    public class GetDataVmCustomMapper : ITypeConverter<User, GetDataVM>
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

        

        public GetDataVM Convert(User source, GetDataVM destination, ResolutionContext context)
        {

          
            GetDataVM dest = new GetDataVM()
            {
                Id = source.Id,
                Role =source.Role.Role,
                ReviewingAuthorityFirstName = source.FirstName,
                ReportingAuthorityFirstName = source.FirstName,

             

            };

            return dest;
            
        }
    }
}
