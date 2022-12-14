using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppraisalTool.Application.Features.Authority.Query.GetAllAuthority
{
    public class GetAllAuthorityQueryVm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public DateTime? JoinDate { get; set; } = DateTime.UtcNow;
        public DateTime? LastAppraisalDate { get; set; }
        public int Role { get; set; }
        public string? RoleName { get; set; }
        public string? PrimaryJobProfileName { get; set; }
        public string? SecondaryJobProfileName { get; set; }
        public int? PrimaryJobProfileId { get; set; }
        public int? SecondaryJobProfileId { get; set; }
        public int? RevaId { get; set; }
        public string? RevaName { get; set; }
        public int? RepaId { get; set; }
        public string? RepaName { get; set; }
        public string? Name { get; set; }
    }
}
