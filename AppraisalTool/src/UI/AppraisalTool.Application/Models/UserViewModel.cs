using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AppraisalTool.App.Models
{
    public class UserViewModel
    {

        public int Id { get; set; }  

        [Required(ErrorMessage = "Please Enter First Name")]
        [RegularExpression(@"^[a-zA-z]+$", ErrorMessage = "First Name Should Contain only Alphabet")]
        [MaxLength(20)]
        [Display(Name = "First Name")]
        public string ?FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please Enter Last Name")]
        [MaxLength(20)]
        [RegularExpression(@"^[a-zA-z]+$", ErrorMessage = "Last Name Should Contain only Alphabet")]
        public string ?LastName { get; set; }

        [Display(Name = "Email Id")]
        [DataType(DataType.EmailAddress)]
        [Remote("UserExistsEmail", "Admin", HttpMethod = "GET", ErrorMessage = "User with this Email exists")]
        [Required(ErrorMessage = "Please Enter Email Id")]
        [RegularExpression(@"^[0-9a-zA-z]+[.+-_$]{0,1}[0-9a-zA-z]+[@][a-zA-z]+[.][a-zA-z]{2,3}$", ErrorMessage = "Please Enter Valid Email")]
        public string ?Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [RegularExpression(@"^[a-zA-z0-9@&*$]{8,}", ErrorMessage = "Enter a strong password")]
        public string ?Password { get; set; }

        [Display(Name = "Join Date")]
        [Required(ErrorMessage = "Please Select Join Date")]
        public DateTime? JoinDate { get; set; }

        //[Required]
        //[Display(Name = "Last Appraisal Date")]
        public DateTime? LastAppraisalDate { get; set; }

        [Required(ErrorMessage = "Please select primary job profile")]
        public string ?PrimaryRole { get; set; }

        [Required(ErrorMessage = "Please select a secondary job profile")]
        public string? SecondaryRole { get; set; }

        [Required(ErrorMessage = "Please select Role")]
        public int? RoleId { get; set; }

        [Required(ErrorMessage = "Please select Branch")]
        public int ?BranchId { get; set; }

        [Required(ErrorMessage = "Please select a Reporting Authority Name")]
        public string RepaId { get; set; }

        [Required(ErrorMessage = "Please select a Reviewing Authority Name")]
        public string RevaId { get; set; }

        [Display(Name = "Branch Name")]
        public string? BranchName { get; set; }

        public int? AddedBy { get; set; }
        public int ?Role { get; set; }
        public string? RoleName { get; set; }
        public string? PrimaryJobProfileName { get; set; }
        public string? SecondaryJobProfileName { get; set; }
        public int? SecondaryJobProfileId { get; set; }
        public int? PrimaryJobProfileId { get; set; }
    }
}
