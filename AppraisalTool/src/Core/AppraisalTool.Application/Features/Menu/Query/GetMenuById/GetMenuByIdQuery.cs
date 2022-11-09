using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Menu.Query.GetMenuById
{
    public class GetMenuByIdQuery:IRequest<Response<GetMenuByIdDto>>
    {
        public GetMenuByIdQuery()
        {

        }

        public GetMenuByIdQuery(int id)
        {
            Menu_Id = id;
        }
        public int Menu_Id { get; set; }
    }
}
