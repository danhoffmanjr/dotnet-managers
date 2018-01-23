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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        public string Rated { get; set; }
        [Display(Name = "Run Time")]
        public string RunTime { get; set; }
        public decimal Rating { get; set; }
    }
}