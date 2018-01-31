using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlog.Models.ManageViewModels
{
    public class IndexViewModel
    {
        public string Username { get; set; }

        public string Fooky { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Role { get; set; }

        public string StatusMessage { get; set; }
    }
}
