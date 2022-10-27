using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AppraisalTool.App.Models.AppraisalToolAuth
{
    public class ForgotPasswordViewModel
    {
        [Required]

        [DataType(DataType.EmailAddress)]
        [Remote("UserExistsEmail", "Login", HttpMethod = "GET", ErrorMessage = "User with this Email DoesNot exists")]
        public string email { get; set; }
    }
}
