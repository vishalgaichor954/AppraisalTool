using System.ComponentModel.DataAnnotations;

namespace AppraisalTool.App.Models
{
    public class ReportingMetricDto
    {
        public int Metric_ID { get; set; }
        public int List_Id { get; set; }

        public string Metric_Description { get; set; }

        public double metric_Weightage { get; set; }

        [Required(ErrorMessage = "Score is a Required Field")]
        [Range(1, 5)]

        public int? Score { get; set; }


        [MinLength(2)]
        public string? Comment { get; set; }
        public double? RepaSelfScore { get; set; }
        public string? RepaSelfComment { get; set; }
    }
}
