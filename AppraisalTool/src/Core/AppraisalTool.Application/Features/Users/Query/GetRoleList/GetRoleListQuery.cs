using AppraisalTool.Application.Response;
using AppraisalTool.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Users.Query.GetRoleList
{
    public class GetRoleListQuery:IRequest<Response<IEnumerable<UserRole>>>
    {
    }
}
