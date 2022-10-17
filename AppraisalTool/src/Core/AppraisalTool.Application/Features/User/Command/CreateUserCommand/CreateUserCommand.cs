using AppraisalTool.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.User.Command.CreateUserCommand
{
    public class CreateUserCommand : IRequest<Response<CreateUserDto>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string LoginId { get; set; }
        public DateTime JoinDate { get; set; }
        public int BranchId { get; set; }
        public string AddedBy { get; set; }

        public CreateUserCommand(string firstName, string lastName, string email, string loginId, DateTime joinDate, int branchId, string addedBy)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            LoginId = loginId;
            JoinDate = joinDate;
            BranchId = branchId;
            AddedBy = addedBy;
        }
    }
}
