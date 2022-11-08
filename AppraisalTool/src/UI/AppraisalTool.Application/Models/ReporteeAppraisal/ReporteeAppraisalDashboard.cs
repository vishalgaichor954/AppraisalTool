namespace AppraisalTool.App.Models.ReporteeAppraisal
{
    public class ReporteeAppraisalDashboard
    {
        public int UserId { get; set; }
        public string? EmployeeName { get; set; }

        public string? PrimaryRole { get; set; }

        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public int FinancialYearId { get; set; }
        public string? Date { get; set; }
        public string? StatusTitle { get; set; }
        public string? ReviewingAuthority { get; set; }


    }
}
