namespace AppraisalTool.App.Models
{
    public class AppraisalResponseVm
    {
        public int Id { get; set; }
        public int FinancialYearId { get; set; }
        public int UserId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? StatusId { get; set; }
        public int? KraId { get; set; }
        public DateTime? ReviewedOn { get; set; }
        public DateTime? ApprovedOn { get; set; }

        //New Added properties
        public bool? Editable { get; set; }
        public bool? EditRequested { get; set; } 

    }
}
