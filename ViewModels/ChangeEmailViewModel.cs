using System.ComponentModel.DataAnnotations;

namespace CinemaPortal_ASP.NET_Core.ViewModels
{

    public class ChangeEmailViewModel
     {
            [Display(Name = "Current email")]
            public string OldEmail { get; set; }

            [Required]
            [Display(Name = "New  Email")]
            public string NewEmail { get; set; }
    }
}
