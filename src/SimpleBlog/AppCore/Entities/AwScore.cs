using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Entities
{
    public class AwScore : Post
    {
        public int PostId { get; set; }
        public decimal UserAwScore { get; set; }
    }
}
