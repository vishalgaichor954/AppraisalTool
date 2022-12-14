using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.UserJobProfileRoles.Command.RemoveJobProfileRoleCommand
{
    public class RemoveJobProfileCommand:IRequest<Response<RemoveJobProfileCommandDto>>

    {
        public RemoveJobProfileCommand() 
        {
            

        }
        public RemoveJobProfileCommand(int id)
        {
            Id = id;

        }
        public int Id { get; set; }
    }
}
