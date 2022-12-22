using AppraisalTool.Application.Models.Encoding;
using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Users.Query.GetUserList
{
    public class GetUserListQuery:IRequest<Response<IEnumerable<GetUserListQueryVm>>>
    {
    }
}
