namespace AppraisalTool.App.Models.FinancialYear
{
    public class FinancialYear
    {
        public int Id { get; set; }
        public int StartYear { get; set ; }
        public int EndYear { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set; }

        public int? AddedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public bool IsActive { get;set; }=false;
    }
}
