using System.ComponentModel.DataAnnotations;

namespace AppraisalTool.App.Models.AppraisalToolAuth
{
    public class Login
    {
        [Required(ErrorMessage = "Please Enter a Value")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required (ErrorMessage = "Please Enter a Value")]
        [RegularExpression(@"^[a-zA-z0-9@&*$]{8,}", ErrorMessage = "Please enter a valid password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(4)]
        public string CaptchaCode { get; set; }
    }
}
