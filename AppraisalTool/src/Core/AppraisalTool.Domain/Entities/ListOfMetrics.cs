using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Domain.Entities
{
    public class ListOfMetrics
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Metric_ID { get; set; }
        public int List_Id { get; set; }

        public string Metric_Description { get; set; }

        public double metric_Weightage { get; set; }

        [ForeignKey("List_Id")]
        public virtual ListOfKra ?ListOfKra { get; set; }


    }
}
