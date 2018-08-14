using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace test5.Models
{
    public class Cake
    {
        public string CakeName { get; set; } //or ID
        public string Image { get; set; }
        public string IsSensitive { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
    }
}