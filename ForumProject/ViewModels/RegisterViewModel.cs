using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ForumProject.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Username")]
        [Remote(action: "IsUserNameValid", controller: "Account")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailValid", controller: "Account")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Display Name")]
        [StringLength(20, 
            ErrorMessage = "The {0} must be at least {2} and {1} characters long.", MinimumLength = 2)]
        public string DisplayName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, 
            ErrorMessage = "The {0} must contain at least {2} and at max {1} characters.", MinimumLength = 8)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confrim password")]
        [Compare("Password", 
            ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
