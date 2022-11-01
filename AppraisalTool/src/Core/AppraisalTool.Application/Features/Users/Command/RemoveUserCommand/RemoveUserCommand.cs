using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Users.Command.RemoveUserCommand
{
    public class RemoveUserCommand : IRequest<Response<RemoveUserCommandDto>>
    {
        public RemoveUserCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }

    }

}
