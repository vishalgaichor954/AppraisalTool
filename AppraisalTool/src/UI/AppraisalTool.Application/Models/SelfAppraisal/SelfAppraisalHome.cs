namespace AppraisalTool.App.Models.SelfAppraisal
{
    public class SelfAppraisalHome
    {
        public int Id { get; set; }
       
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        
        public int FinancialYearId { get; set; }
        public int AppraisalsToBeFilled { get; set; }
        public int PendingAppraisals { get; set; } 
        public string? LastDate { get; set; } 
    }
}
