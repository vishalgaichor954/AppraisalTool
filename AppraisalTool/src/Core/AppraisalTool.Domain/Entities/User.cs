using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Domain.Entities
{
    public class User
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Byte[]? PasswordHash { get; set; } = null;
        public Byte[]? PasswordSalt { get; set; } = null;
        public DateTime? JoinDate { get; set; }
        public DateTime? LastAppraisalDate { get; set; }
        public int RoleId { get; set; }
        public int BranchId { get; set; }
        public int? AddedBy { get; set; }
        public DateTime AddedOn { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedOn { get; set; }
        public int? DeletedBy{ get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        [ForeignKey("AddedBy")]
        public virtual User? AddedByUser { get; set; }
        [ForeignKey("DeletedBy")]
        public virtual User? DeletedByUser { get; set; }

        [ForeignKey("RoleId")]
        public virtual UserRole? Role { get; set; }
        [ForeignKey("BranchId")]
        public virtual Branch? Branch { get; set; }
        
        public virtual List<UserJobRoles> JobRoles { get; set; }

        public virtual List<Appraisal>? UserAppraisals { get; set; }


        //public virtual List<UserAuthorityMapping> UserAuthorities { get; set; }


    }
}
