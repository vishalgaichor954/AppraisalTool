namespace AppraisalTool.App.Models
{
    public class SelfAppraisalMetricsModel
    {
        public List<MetricsDto> IMetric { get; set; }
        public List<MetricsDto> BevMetric { get; set; }
        public List<MetricsDto> JobMetric { get; set; }

    }
}
