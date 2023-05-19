using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class UserSignInModel
    {
        [Required(ErrorMessage = "Enter you email")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter you password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "Remember me")]
        public bool Remember { get; set; }
    }
}
