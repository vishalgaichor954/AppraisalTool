﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AppraisalTool.App.Models
{
    public class UserViewModel
    {

        public int Id { get; set; }  

       [Required(ErrorMessage = " ")]
        [RegularExpression(@"^[a-zA-z]+$", ErrorMessage = "First Name Should Contain only Alphabet")]
        [MaxLength(20)]
        [Display(Name = "First Name")]
        public string ?FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = " ")]
        [MaxLength(20)]
        [RegularExpression(@"^[a-zA-z]+$", ErrorMessage = "Last Name Should Contain only Alphabet")]
        public string ?LastName { get; set; }

        [Display(Name = "Email Id")]
        [DataType(DataType.EmailAddress)]
        [Remote("UserExistsEmail", "Admin", HttpMethod = "GET", ErrorMessage = "User with this Email exists")]
        [Required(ErrorMessage = " ")]
        [RegularExpression(@"^[0-9a-zA-z]+[.+-_$]{0,1}[0-9a-zA-z]+[@][a-zA-z]+[.][a-zA-z]{2,3}$", ErrorMessage = "Please Enter Valid Email")]
        public string ?Email { get; set; }

        [Required(ErrorMessage = " ")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,32}$", ErrorMessage = "Enter a strong password")]
        public string ?Password { get; set; }


        [Display(Name = "Join Date")]
       [Required(ErrorMessage = " ")]
        public DateTime? JoinDate { get; set; }

        [Required(ErrorMessage = " ")]
        [Display(Name = "Last Appraisal Date")]
        public DateTime? LastAppraisalDate { get; set; }

        [Required(ErrorMessage = " ")]
        public string ?PrimaryRole { get; set; }

        [Required(ErrorMessage = " ")]
        public string? SecondaryRole { get; set; }

        [Required(ErrorMessage = " ")]
        public int? RoleId { get; set; }

        [Required(ErrorMessage = " ")]
        public int ?BranchId { get; set; }

        [Required(ErrorMessage = " ")]
        public string RepaId { get; set; } = "0";

        [Required(ErrorMessage = " ")]
        public string RevaId { get; set; } = "0";

        [Display(Name = "Branch Name")]
        public string? BranchName { get; set; }

        public int? AddedBy { get; set; }
        public int ?Role { get; set; }
        public string? RoleName { get; set; }
        public string? PrimaryJobProfileName { get; set; }
        public string? SecondaryJobProfileName { get; set; }
        public int? SecondaryJobProfileId { get; set; }
        public int? PrimaryJobProfileId { get; set; }

        public string RevaName { get; set; }

        public string RepaName { get; set; }
    }
}
