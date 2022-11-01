using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Users.Query.GetUserList
{
    public class GetUserListQueryVm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public DateTime JoinDate { get; set; } = DateTime.UtcNow;
        public DateTime? LastAppraisalDate { get; set; }

    }
}
