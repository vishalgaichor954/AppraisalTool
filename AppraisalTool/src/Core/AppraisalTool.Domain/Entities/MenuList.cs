using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Domain.Entities
{
    public class MenuList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Menu_Id { get; set; }

        public string MenuText { get; set; }

        public string MenuClass { get; set; }
        public string MenuIcon { get; set; }

        public string ?MenuFlag { get; set; }
        public string ?MenuController { get; set; }

        public string ?MenuAction { get; set; }

        public string ?MenuLink { get; set; }

        public int? AddedBy { get; set; }
        public DateTime AddedOn { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedOn { get; set; }=DateTime.UtcNow;
        public int? DeletedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }= DateTime.UtcNow;

        [ForeignKey("AddedBy")]
        public virtual User? AddedByUser { get; set; }
        [ForeignKey("DeletedBy")]
        public virtual User? DeletedByUser { get; set; }

        [ForeignKey("UpdatedBy")]
        public virtual User? UpdatedByByUser { get; set; }


        //public virtual MenuRoleMapping RoleMapping { get; set; }


    }
}
