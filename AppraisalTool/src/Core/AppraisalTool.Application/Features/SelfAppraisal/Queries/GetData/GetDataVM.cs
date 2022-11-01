using AppraisalTool.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.SelfAppraisal.Queries.GetData
{
    public class GetDataVM
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StatusId { get; set; }
        public DateTime ReviewedOn { get; set; }
        public DateTime ApprovedOn { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public string Role { get; set; }
        public int FinancialYearId { get; set; }


    }
}
