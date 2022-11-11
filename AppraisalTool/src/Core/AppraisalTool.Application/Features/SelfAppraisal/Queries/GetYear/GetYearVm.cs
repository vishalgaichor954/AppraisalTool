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
        public int AppraisalsToBeFilled { get; set; } = 1;
        public int PendingAppraisals { get; set; } = 0;
        public string LastDate { get; set; } = "31st March 2022";
        public string CurrentYear { get; set; } = "FY2022-2023";

    }
}
