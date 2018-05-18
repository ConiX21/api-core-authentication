using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiPizza.Models
{
    public partial class Pizza
    {
        public short IdPizza { get; set; }
        public short IdCategory { get; set; }

        [RegularExpression("^[0-9A-Z ]{1,50}$")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public decimal? Price { get; set; }
        public bool? Available { get; set; }

        public Category Category { get; set; }
    }
}
