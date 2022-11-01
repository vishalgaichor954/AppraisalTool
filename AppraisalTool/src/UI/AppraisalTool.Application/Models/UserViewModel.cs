using System.ComponentModel.DataAnnotations;

namespace AppraisalTool.App.Models
{
    public class UserViewModel
    {

        public int Id { get; set; }  

        [Required(ErrorMessage = "First Name is Required")]
        [RegularExpression(@"^[a-zA-z]+$", ErrorMessage = "First Name Should Contain only Alphabet")]

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Last Name is Required")]
        [RegularExpression(@"^[a-zA-z]+$", ErrorMessage = "Last Name Should Contain only Alphabet")]
        public string LastName { get; set; }

        [Display(Name = "Email Id")]
        [Required(ErrorMessage = "Email Address is Required")]
        [RegularExpression(@"^[0-9a-zA-z]+[.+-_$]{0,1}[0-9a-zA-z]+[@][a-zA-z]+[.][a-zA-z]{2,3}$", ErrorMessage = "Please Enter Valid Email")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-z0-9@&*$]{8,}", ErrorMessage = "password pattern not match")]
        public string Password { get; set; }

        [Display(Name = "Join Date")]
        [Required]
        public DateTime? JoinDate { get; set; }

        [Required]
        [Display(Name = "Last Appraisal Date")]
        public DateTime? LastAppraisalDate { get; set; }

        [Required(ErrorMessage = "Please Select PrimaryRole")]
        public string PrimaryRole { get; set; }

        [Required(ErrorMessage = "Please Select SecondaryRole")]
        public string SecondaryRole { get; set; }

        [Required(ErrorMessage = "Please Select Roles")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "Please Select Branch")]
        public int BranchId { get; set; }

        [Display(Name = "Branch Name")]
        public string BranchName { get; set; }
    }
}
