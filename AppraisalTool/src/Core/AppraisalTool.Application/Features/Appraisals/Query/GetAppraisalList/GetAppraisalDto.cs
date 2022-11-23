using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Appraisals.Query.GetAppraisalList
{
    public class GetAppraisalDto
    {
        public int AppraisalId { get; set; }
        public int UserId { get; set; }
        public string ? Firstname { get; set; }
        public string? LastName { get; set; }


        
        public int FinanceYearId { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }

        public int? StatusId { get; set; }
        public string? StatusName { get; set; }


    }
}
