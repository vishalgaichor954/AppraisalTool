using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Menu.Command.CreateMenuCommand
{
    public class CreateMenuCommand:IRequest<Response<CreateMenuCommandDto>>
    {
        public string MenuText { get; set; }

        public string MenuClass { get; set; }
        public string MenuIcon { get; set; }

        public string? MenuFlag { get; set; }
        public string? MenuController { get; set; }

        public string? MenuAction { get; set; }

        public string? MenuLink { get; set; }

        public int? AddedBy { get; set; }

        public int RoleId { get; set; }
    }
}
