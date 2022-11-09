using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Menu.Query.GetMenuList
{
    public class GetMenuListQueryVm
    {
        public int Menu_Id { get; set; }
        public string MenuText { get; set; }

        public string MenuClass { get; set; }
        public string MenuIcon { get; set; }

        public string? MenuFlag { get; set; }
        public string? MenuController { get; set; }

        public string? MenuAction { get; set; }

        public string? MenuLink { get; set; }

        public string RoleName { get; set; }
    }
}
