using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Models.AppraisalTool
{
    public class ReporteeAppraisalFilter
    {
        public int? PrimaryRole { get; set; }
        public DateTime? StartDate{ get; set; }
        public DateTime? EndDate { get; set; }
        public int? EmployeeName { get; set; }
        public int? ReviewingAuthority { get; set; }
        public int? Status { get; set; }
    }
}
