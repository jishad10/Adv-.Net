using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LabExam.DTOs
{
    public class RegisterDTO
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Uname")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "The Name field should only contain letters and spaces.")]
        public string Uname { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [MinLength(4, ErrorMessage = "The Password must be at least 8 characters long.")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        public string Type { get; set; }
    }
}