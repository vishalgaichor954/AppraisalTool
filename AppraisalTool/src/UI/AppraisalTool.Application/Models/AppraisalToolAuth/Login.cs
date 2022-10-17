﻿using System.ComponentModel.DataAnnotations;

namespace AppraisalTool.App.Models.AppraisalToolAuth
{
    public class Login
    {
        [Required(ErrorMessage = "Please Enter a Value")]
        [RegularExpression(@"^[a-zA-z]+$", ErrorMessage = "Letter only Allowed")]
        public string UserName { get; set; }


        [Required (ErrorMessage = "Please Enter a Value")]
        [RegularExpression(@"^[a-zA-z0-9@&*$]{8,}", ErrorMessage = "Please enter a valid password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
