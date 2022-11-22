using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Domain.Common
{
    public class ReviewAppraisalListVm
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? AppraisalId { get; set; }
        public int? EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? RepAuthorityId { get; set; }
        public string? RepaName { get; set; }
        public int? AppraisalStatusId { get; set; }
        public string? AppraisalStatus { get; set; }
        public int? FinancialStartYear { get; set; }
        public int? FinancialEndYear { get; set; }
        public int? FinancialYearId { get; set; }
        public int? Status { get; set; }

    }
}
