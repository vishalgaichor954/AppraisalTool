using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.UserRoles.Command.RemoveUserRoleCommand
{
    public class RemoveUserRoleCommandDto
    {
        public string? Message { get; set; }
        public bool Succeeded { get; set; }
    }
}
