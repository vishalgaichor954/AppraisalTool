using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Menu.Command.RemoveMenuCommand
{
    public class RemoveMenuCommandDto
    {
        public int Menu_Id { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }
}
