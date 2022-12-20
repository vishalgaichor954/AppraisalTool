namespace AppraisalTool.App.Dtos
{
    public class UserEncodeDto
    {
        public string Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? JoinDate { get; set; }
        public DateTime? LastAppraisalDate { get; set; }
        public string? PrimaryRole { get; set; }
        public string? SecondaryRole { get; set; }
        public int? RoleId { get; set; }
        public int? BranchId { get; set; }
        public string RepaId { get; set; } = "0";
        public string RevaId { get; set; } = "0";
        public string? BranchName { get; set; }
        public int? AddedBy { get; set; }
        public int? Role { get; set; }
        public string? RoleName { get; set; }
        public string? PrimaryJobProfileName { get; set; }
        public string? SecondaryJobProfileName { get; set; }
        public int? SecondaryJobProfileId { get; set; }
        public int? PrimaryJobProfileId { get; set; }

        public string RevaName { get; set; }

        public string RepaName { get; set; }
    }
}
