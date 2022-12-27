using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Domain.Entities
{
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }

        public string NotificationText { get; set; }

        public DateTime NotificationDate { get; set; }= DateTime.Now;

        public bool IsRead { get; set; }
        [ForeignKey("UserId")]
        public virtual User? User { get; set; }

    } 
}
