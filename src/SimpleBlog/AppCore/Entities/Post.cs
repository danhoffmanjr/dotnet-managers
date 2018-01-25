using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppCore.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Permalink { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
        [Display(Name = "Post Rating")]
        [DisplayFormat(DataFormatString = "{0:00.00}")]
        public double AvgAwScore { get; set; }
        public int AwScore { get; set; }
        public List<int> AwScores { get; set; }
    }
}
