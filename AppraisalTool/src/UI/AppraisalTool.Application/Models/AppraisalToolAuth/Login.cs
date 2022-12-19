using System.ComponentModel.DataAnnotations;

namespace AppraisalTool.App.Models.AppraisalToolAuth
{
    public class Login
    {
        [Required(ErrorMessage = " ")]
        [DataType(DataType.EmailAddress)]
       [RegularExpression(@"^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4})*$", ErrorMessage = " ")]
        public string Email { get; set; }


        [Required(ErrorMessage = " ")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^[a-zA-z0-9@&*$]{8,}", ErrorMessage = " ")]
       
        public string Password { get; set; }

        [Required(ErrorMessage = " ")]
        [StringLength(4)]
        public string CaptchaCode { get; set; }
    }
}
