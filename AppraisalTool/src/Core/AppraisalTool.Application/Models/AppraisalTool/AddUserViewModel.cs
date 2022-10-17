using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Models.AppraisalTool
{
    public class AddUserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get;set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime JoinDate { get; set; } = DateTime.UtcNow;
        public DateTime? LastAppraisalDate { get; set; }
        public int RoleId { get; set; }
        public int BranchId { get; set; }
        public int? AddedBy { get; set; } = null;
    }
}
