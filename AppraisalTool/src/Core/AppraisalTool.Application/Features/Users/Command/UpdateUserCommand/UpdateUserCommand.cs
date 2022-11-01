using AppraisalTool.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Users.Command.UpdateUserCommand
{
    public class UpdateUserCommand:IRequest<Response<UpdateUserCommandDto>>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? LastAppraisalDate { get; set; }
        public int RoleId { get; set; }
        public int BranchId { get; set; }
    }
}
