using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.UserRoles.Query.GetUserRoleById
{
    public class GetUserRoleByIdQuery:IRequest<Response<GetUserRoleByIdQueryDto>>
    {
        public GetUserRoleByIdQuery()
        {

        }
        public GetUserRoleByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
