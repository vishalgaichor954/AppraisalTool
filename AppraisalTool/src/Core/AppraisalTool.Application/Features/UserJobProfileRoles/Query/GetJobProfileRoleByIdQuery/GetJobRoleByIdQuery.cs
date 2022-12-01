using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.UserJobProfileRoles.Query.GetJobProfileRoleByIdQuery
{
    public class GetJobRoleByIdQuery:IRequest<Response<GetJobRoleByIdQueryDto>>
    {
        public GetJobRoleByIdQuery()
        {

        }
        public GetJobRoleByIdQuery(int id)
        {
            Id = id;

        }
        public int Id { get; set; }
    }
}
