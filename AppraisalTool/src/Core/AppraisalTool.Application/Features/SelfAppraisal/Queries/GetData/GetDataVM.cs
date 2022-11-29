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
        
        //public int ReportingAuthorityId { get; set; }
        
        public string? ReviewingAuthorityFirstName { get; set; }
        public string? ReviewingAuthorityLastName { get; set; }

        public string? ReportingAuthorityFirstName { get; set; }
        public string? ReportingAuthorityLastName { get; set; }

        //public int AuthorityId { get; set; }
        //public DateTime StartDate { get; set; }
        //public DateTime EndDate { get; set; }
        //public int StatusId { get; set; }
        //public DateTime ReviewedOn { get; set; }
        //public DateTime ApprovedOn { get; set; }
        //public int StartYear { get; set; }
        //public int EndYear { get; set; }
        public string? Role { get; set; }
        public string? AppraisalStatus { get; set; } /*= "Pending at Authority Level";*/
        public string? Date { get; set; } 
        public int FinancialYearId { get; set; }

        public int StartYear { get; set; }
        public int EndYear { get; set; }

        public string? StartDate { get; set; }
        public string? EndDate { get; set; }


    }
}
