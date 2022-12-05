using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.UserRoles.Command.UpdateUserRoleCommand
{
    public class UpdateUserRolesCommand:IRequest<Response<UpdateUserRolesCommandDto>>
    {
        public int Id { get; set; }
        public string? Role { get; set; }
    }
}
