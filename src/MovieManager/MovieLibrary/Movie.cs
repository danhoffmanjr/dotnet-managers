using System;
using System.ComponentModel.DataAnnotations;

namespace MovieLibrary
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        [Display(Name = "Description")]
        public string ShortDesc { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        public string Rated { get; set; }
        [Display(Name = "Movie Length")]
        [DisplayFormat(DataFormatString = "{0:\\ h}h {0:mm}min")]
        public TimeSpan RunTime { get; set; }
        [Display(Name = "Average Customer Rating")]
        public decimal Rating { get; set; }
    }
}