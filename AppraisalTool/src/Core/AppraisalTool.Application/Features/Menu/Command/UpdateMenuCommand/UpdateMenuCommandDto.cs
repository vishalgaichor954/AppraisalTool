using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Menu.Command.UpdateMenuCommand
{
    public class UpdateMenuCommandDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }
}
