using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Users.Command.CreateRoleCommand
{
    public class CreateRoleCommands:IRequest<Response<CreateRoleCommandDto>>
    {
        public int UserId { get; set; }
        public int JobRoleId { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsSecondary { get; set; }
    }
}
