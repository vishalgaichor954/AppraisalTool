using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Branches.Command.RemoveBranchCommand
{
    public class RemoveBranchesCommandDto
    {
        public string? Message { get; set; }
        public bool Succeeded { get; set; }
    }
}
