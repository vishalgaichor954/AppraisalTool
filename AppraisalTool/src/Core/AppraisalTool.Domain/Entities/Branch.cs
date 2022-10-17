using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Domain.Entities
{
    public class Branch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }
        public string? AddedBy { get; set; }
        public DateTime AddedOn { get; set; } = DateTime.UtcNow;
    }
}
