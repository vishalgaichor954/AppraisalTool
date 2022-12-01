using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.UserJobProfileRoles.Command.UpdateJobProfileRoleCommand
{
    public class UpdateJobProfileCommand:IRequest<Response<UpdateJobProfileCommandDto>>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
