using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Domain.Entities
{
    public class JobRoles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;

        //New Properties
        [ForeignKey("User")]
        public int AddedBy { get; set; }
        public DateTime? AddedOn { get; set; } = DateTime.UtcNow;
        public bool? IsDeleted { get; set; } = false;
        public DateTime? DeletedOn { get; set; } = DateTime.UtcNow;
        [ForeignKey("User")]
        public int? DeletedBy { get; set; }
        [ForeignKey("User")]
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; } = DateTime.UtcNow;
    }
}
