using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.SelfAppraisal.Queries.GetYear
{
    public class GetYearVm
    {
        public int Id { get; set; }

        public int StartYear { get; set; }
        public int EndYear { get; set; }
    }
}
