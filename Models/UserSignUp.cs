using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace BookStore.Models
{
    public class UserSignUp
    {
        [Required(ErrorMessage = "Enter you email")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Enter your first name")]
        [Display(Name = "First Name")]
        [StringLength(30,MinimumLength = 3, ErrorMessage = "{0} must contain from  {2} to {1} characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter your last name")]
        [Display(Name = "Last Name")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "{0} must contain from  {2} to {1} characters.")]
        public string LastName { get; set; }



        [Required(ErrorMessage = "Enter you passwird")]
        [Compare("ConfirmPassword",ErrorMessage = "Password does not match")]
        [Display(Name ="Passwird")]
        [DataType(DataType.Password)]
        public string Password { get; set; }



        [Required(ErrorMessage = "Enter you password again")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]

        public string ConfirmPassword { get; set; }



    }
}
