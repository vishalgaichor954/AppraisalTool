using System.ComponentModel.DataAnnotations;

namespace AppraisalTool.App.Models.UserRole
{
    public class UserRole
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Role Name")]
        public string? Role { get; set; }

        public int? AddedBy { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
