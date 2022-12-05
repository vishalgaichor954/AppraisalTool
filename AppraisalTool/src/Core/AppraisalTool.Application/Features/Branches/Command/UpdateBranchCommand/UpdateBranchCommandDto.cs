using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Branches.Command.UpdateBranchCommand
{
    public class UpdateBranchCommandDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }
}
