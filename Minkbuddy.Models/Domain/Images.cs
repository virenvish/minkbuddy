using System;
using System.Collections.Generic;
using System.Text;

namespace Minkbuddy.Models.Domain
{
    public class Images
    {
        public int Id { get; set; }
        public string FullImage { get; set; }
        public string Thumbnail { get; set; }
        public string Base { get; set; }
        public string Small { get; set; }
        public int ImageFor { get; set;
        }    
    }
}
