using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.UserRoles.Command.RemoveUserRoleCommand
{
    public class RemoveUserRolesCommand:IRequest<Response<RemoveUserRoleCommandDto>>
    {
        public RemoveUserRolesCommand()
        {


        }
        public RemoveUserRolesCommand(int id)
        {
            Id = id;

        }
        public int Id { get; set; }
    }
}

