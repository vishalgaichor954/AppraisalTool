using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Users.Query.GetUserByRoleId
{
    public class GetUserByRoleIdQuery:IRequest<Response<IEnumerable<GetUserByRoleIdDto>>>
    {
        public GetUserByRoleIdQuery()
        {
            
        }
        public GetUserByRoleIdQuery(int id)
        {
            RoleId = id;
        }
        public int RoleId { get; set; }
    }
}
