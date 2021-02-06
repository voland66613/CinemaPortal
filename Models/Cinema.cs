using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CinemaPortal_ASP.NET_Core.Models
{
    public class Cinema
    {
        //CinemaID. This is the primary key
        public int CinemaID { get; set; }

        //Title. The name of the cinema
        [Required]
        [DisplayName("Name:")]
        public string Name { get; set; }

        //Poster. This is a picture file
        [DisplayName("Poster:")]
        [MaxLength]
        public byte[] Poster { get; set; }

        //ImageMimeType, stores the MIME type for the Poster
        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }

        [Display(Name = "Producer:")]
        public string FilmMaker { get; set; }


        [Display(Name = "Description:")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        //CreatedDate
        [DisplayName("Year:")]
        public int Year { get; set; }

        //UserName. This is the name of the user who created the photo
        [DisplayName("User:")]
        public string UserName { get; set; }

    }
}
