namespace AppraisalTool.App.Models.FinancialYear
{
    public class financialResponse
    {
        public string Message { get; set; }
        public bool Succeeded { get; set; }

        public string Errors { get; set; }
        public GetFinancialYearByIdDto Data { get; set; }
    }
}
