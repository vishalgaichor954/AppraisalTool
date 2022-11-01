namespace AppraisalTool.App.Models.AppraisalToolAuth
{
    public class SelfAppraisalHome
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
