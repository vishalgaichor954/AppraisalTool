using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppraisalTool.Identity.Models
{
    public class ApplicationUser : IdentityUser
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string LoginId { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime LastAppraisalDate { get; set; }
        public string PrimaryJobRole { get; set; }
        public string AdditionalRole1 { get; set; }
        public string AdditionalRole2 { get; set; }
        public string AdditionalRole3 { get; set; }
        public string AdditionalRole4 { get; set; }
        public  int BranchId { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedOn { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeletedBy { get; set; }

        [ForeignKey("AddedBy")]
        public virtual ApplicationUser AddedByUser { get; set; }
        [ForeignKey("DeletedBy")]
        public virtual ApplicationUser DeletedByUser { get; set; }

        [NotMapped]
        [ForeignKey("BranchId")]
        public virtual Branch Branch { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}
