using System.ComponentModel.DataAnnotations;

namespace CinemaPortal_ASP.NET_Core.ViewModels
{

    public class ChangeUserNameViewModel
     {
            [Display(Name = "Old Name")]
            public string OldUserName { get; set; }

            [Required]
            [Display(Name = "New Name")]
            public string NewUserName { get; set; }
    }
}
