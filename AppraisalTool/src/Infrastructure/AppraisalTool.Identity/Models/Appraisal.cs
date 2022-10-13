using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Identity.Models
{
    public class Appraisal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int FinancialYearId { get; set; }
        public string UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ReportingAuthorityId { get; set; }
        public string ReviewingAuthorityId { get; set; }
        public int StatusId { get; set; }
        public int? KraId { get; set; }
        public DateTime ReviewedOn { get; set; }
        public DateTime ApprovedOn { get; set; }

        [ForeignKey("FinancialYearId")]
        public virtual FinancialYear FinancialYear { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        [ForeignKey("ReportingAuthorityId")]
        public virtual ApplicationUser ReportingAuthority { get; set; }
        [ForeignKey("ReviewingAuthorityId")]
        public virtual ApplicationUser ReviewingAuthority { get; set; }
        [ForeignKey("StatusId")]
        public virtual Status Status { get; set; }

    }
}
