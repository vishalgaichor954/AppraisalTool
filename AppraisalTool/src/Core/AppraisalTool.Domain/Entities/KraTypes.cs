using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Domain.Entities
{
    public class KraTypes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Kra_Type_ID { get; set; }

        public string Kra_Description { get; set; }

        //public virtual List<ListOfKra> ?listOfKra { get; set; }
    }
}
