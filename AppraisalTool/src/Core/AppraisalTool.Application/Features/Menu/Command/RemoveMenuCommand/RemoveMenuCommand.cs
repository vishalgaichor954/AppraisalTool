using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Menu.Command.RemoveMenuCommand
{
    public class RemoveMenuCommand:IRequest<Response<RemoveMenuCommandDto>>
    {
        public RemoveMenuCommand()
        {
            
        }
        public RemoveMenuCommand(int id)
        {
            Menu_Id = id;
        }
        public int Menu_Id { get; set; }
    }
}
