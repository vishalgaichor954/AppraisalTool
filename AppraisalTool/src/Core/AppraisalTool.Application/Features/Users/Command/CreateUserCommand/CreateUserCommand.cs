using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Users.Command.CreateUserCommand
{
    public class CreateUserCommand : IRequest<Response<CreateUserDto>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime JoinDate { get; set; } = DateTime.UtcNow;
        public DateTime? LastAppraisalDate { get; set; }
        public int RoleId { get; set; }
        public int BranchId { get; set; }

        //public int PrimaryRole { get; set; }

        //public int SecondaryRole { get; set; }


    }
}
