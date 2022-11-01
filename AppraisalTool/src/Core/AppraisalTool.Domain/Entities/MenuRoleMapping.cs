using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Domain.Entities
{
    public class MenuRoleMapping
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuRoleMapping_id { get; set; }
        public int Menu_id { get; set; }

        public int Role_id { get; set; }
        [ForeignKey("Role_id")]
        public virtual UserRole UserRole { get; set; }
        [ForeignKey("Menu_id")]
        public virtual MenuList MenuList { get; set; }


    }
}

