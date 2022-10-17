using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Domain.Entities
{
    public class UserAuthorityMapping
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ReportingAuthorityId { get; set; }
        public int ReviewingAuthorityId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("ReportingAuthorityId")]
        public virtual User ReportingAuthority { get; set; }
        [ForeignKey("ReviewingAuthorityId")]
        public virtual User ReviewingAuthority { get; set; }
    }
}
