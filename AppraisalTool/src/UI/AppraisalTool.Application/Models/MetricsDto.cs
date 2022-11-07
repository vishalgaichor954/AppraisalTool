
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppraisalTool.App.Models
{
    public class MetricsDto
    {

        public int Metric_ID { get; set; }
        public int List_Id { get; set; }

        public string Metric_Description { get; set; }

        public double metric_Weightage { get; set; }

        //[Required]
        public string? Score { get; set; }

        //[Required]
        //[MinLength(2)]
        public string? Comment { get; set; }


    }
}
