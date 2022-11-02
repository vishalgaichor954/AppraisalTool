using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Users.Query.GetUserById
{
    public class GetUserByIdQuery:IRequest<Response<GetUserByIdDto>>
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
