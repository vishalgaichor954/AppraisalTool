using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Domain.Entities
{
    public class ListOfKra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int List_Id { get; set; }

        public int Kra_Type_ID { get; set; }
       
        public string List_Kra_Description { get; set; }
        [ForeignKey("Kra_Type_ID")]
        public virtual KraTypes ?KraTypes { get; set; } 
        
        public virtual ICollection<ListOfMetrics> ?ListOfMetrics { get; set; }


    }
}
