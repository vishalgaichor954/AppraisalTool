﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Domain.Common
{
    public class ReporteeAppraisalListVm
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? RevaName { get; set; }
        public string? AppraisalStatus { get; set; }
        public int? FinancialStartYear { get; set; }
        public int? FinancialEndYear { get; set; }
        public int? FinancialYearId { get; set; }
    }
}
