namespace AppraisalTool.App.Models.SelfAppraisal
{
    public class SelfAppraisalDashboard
    {
        public int Id { get; set; }
        public string? ReportingAuthorityFirstName { get; set; }
        
        public string? ReviewingAuthorityFirstName { get; set; }
        public string? Role { get; set; }
        public string? Date { get; set; }
    }
}
