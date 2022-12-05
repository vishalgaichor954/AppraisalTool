using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.UserRoles.Command.CreateUserRoleCommand
{
    public class CreateUserRolesCommand:IRequest<Response<CreateUserRolesCommandDto>>
    {
        public string? Role { get; set; }
    }
}
