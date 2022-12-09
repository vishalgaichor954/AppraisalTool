namespace AppraisalTool.App.Models
{
    public class pendingAppraisalVm
    {

        public int id { get; set; }
        public int financialYearId { get; set; }
        public int userId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public int statusId { get; set; }
     


    }
}
