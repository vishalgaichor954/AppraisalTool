using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Domain.Common
{
    public class GradeChartsData
    {
        public int GaugeMinValue { get; set; } = 0;
        public int GaugeMaxValue { get; set; } = 70;
        public int TotalObtainedScore { get; set; }
        public int TotalWeightage { get; set; }
        public int InputMetricWeightage { get; set; }
        public int InputMetricObtainedScore { get; set; }
        public int BehaviouralMetricWeightage { get; set; }
        public int BehaviouralMetricObtainedScore { get; set; }
        public int JobGroomingMetricWeightage { get; set; }
        public int JobGroomingMetricObtainedScore { get; set; }
    }
}
