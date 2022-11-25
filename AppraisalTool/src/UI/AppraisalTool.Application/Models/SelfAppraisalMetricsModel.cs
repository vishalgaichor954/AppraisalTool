namespace AppraisalTool.App.Models
{
    public class SelfAppraisalMetricsModel
    {
        public List<updateSelfAppraisalVM> IMetric { get; set; }
        public List<updateSelfAppraisalVM> BevMetric { get; set; }
        public List<updateSelfAppraisalVM> JobMetric { get; set; }

    }
}
