using AppraisalTool.Application.Features.Users.Query.GetUserList;
using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Users.Query.GetUserById
{
    public class GetUserByIdQuery:IRequest<Response<GetUserListQueryVm>>
    {
        public GetUserByIdQuery()
        {
        }

        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
