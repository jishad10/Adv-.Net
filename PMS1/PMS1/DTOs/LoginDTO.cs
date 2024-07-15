using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PMS1.DTOs
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Username is required.")]
        [Display(Name = "Username")]
        [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters.")]
        public string Uname { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [MinLength(4, ErrorMessage = "The Password must be at least 4 characters long.")]
        public string Password { get; set; }
    }

}