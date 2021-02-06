using System.ComponentModel.DataAnnotations;

namespace CinemaPortal_ASP.NET_Core.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Old  Password")]
        public string OldPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New  Password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "New password and its confirmation do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
