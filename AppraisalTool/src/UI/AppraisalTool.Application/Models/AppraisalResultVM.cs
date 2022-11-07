﻿namespace AppraisalTool.App.Models
{
    public class AppraisalResultVM
    {
        public int? ID { get; set; }
        public int UserId { get; set; } //FK
        public int KraListId { get; set; } //FK
        public int MetricId { get; set; } //FK
        public string? MetricDescription { get; set; }
        public double? MetricWeightage { get; set; }
        public double? SelfScore { get; set; }
        public string? SelfComment { get; set; }
        public DateTime? SelfCreatatedDate { get; set; }
        public double? RepaSelfScore { get; set; }
        public string? RepaSelfComment { get; set; }
        public DateTime? RepaSelfCreatatedDate { get; set; }
        public double? RevaSelfScore { get; set; }
        public string? RevaSelfComment { get; set; }
        public DateTime? RevaSelfCreatatedDate { get; set; }
    }
}
