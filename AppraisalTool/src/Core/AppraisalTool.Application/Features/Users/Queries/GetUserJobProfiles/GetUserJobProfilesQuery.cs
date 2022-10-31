using AppraisalTool.Application.Responses;
using AppraisalTool.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Users.Queries.GetUserJobProfiles
{
    public class GetUserJobProfilesQuery: IRequest<Response<UserJobProfilesDto>>
    {
        public int Id { get; set; }
    }
}
