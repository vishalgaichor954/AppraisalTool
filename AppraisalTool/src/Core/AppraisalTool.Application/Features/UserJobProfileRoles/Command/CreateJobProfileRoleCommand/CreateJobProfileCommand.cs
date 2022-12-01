using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.UserJobProfileRoles.Command.CreateJobProfileRoleCommand
{
    public class CreateJobProfileCommand:IRequest<Response<CreateJobProfileCommandDto>>
    {
        public string? Name { get; set; }
    }
}
