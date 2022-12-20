using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Domain.Entities
{
    public class UserJobRoles
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public int? JobRoleId { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsSecondary { get; set; }

        [ForeignKey("UserId")]
        public virtual User RoleUser { get; set; }
        [ForeignKey("JobRoleId")]
        public virtual JobRoles JobRole { get; set; }
    }
}
