using System.ComponentModel.DataAnnotations;

namespace AppraisalTool.App.Models.AppraisalToolAuth
{
    public class Login
    {
        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4})*$", ErrorMessage = "Please Enter A Valid Email Address")]
        public string Email { get; set; }


        [Required (ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^[a-zA-z0-9@&*$]{8,}", ErrorMessage = "Please enter a valid password")]
       
        public string Password { get; set; }

        [Required(ErrorMessage = " Captcha code is required")]
        [StringLength(4)]
        public string CaptchaCode { get; set; }
    }
}
