using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.User.Command.CreateUserCommand
{
    public class CreateUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string LoginId { get; set; }
        public DateTime JoinDate { get; set; }
        public int BranchId { get; set; }
        public string AddedBy { get; set; }
    }
}
