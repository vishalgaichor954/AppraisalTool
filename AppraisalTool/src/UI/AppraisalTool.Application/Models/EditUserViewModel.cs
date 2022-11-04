namespace AppraisalTool.App.Models
{
    public class EditUserViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ?Password { get; set; }
        public DateTime? LastAppraisalDate { get; set; }
        public DateTime? JoinDate { get; set; }
        public int? RoleId { get; set; }
        public int? BranchId { get; set; }

        public int? PrimaryRole { get; set; }
        public int? SecondaryRole { get; set; }
    }
}
