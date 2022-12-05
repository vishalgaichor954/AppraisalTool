using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Users.Command.AssignAuthorityCommand
{
    public  class AssignAuthorityCommand:IRequest<Response<AssignAuthorityCommandDto>>
    {
        public int Id { get; set; }
        public int RepaId { get; set; }
        public int RevaId { get; set; }

    }
}
