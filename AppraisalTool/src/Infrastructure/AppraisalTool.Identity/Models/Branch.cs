using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Metrics;


namespace AppraisalTool.Identity.Models
{
    public class Branch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedOn { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }

        [ForeignKey("AddedBy")]
        public virtual ApplicationUser AddedByUser { get; set; }
        [ForeignKey("DeletedBy")]
        public virtual ApplicationUser DeletedByUser { get; set; }
    }
}
