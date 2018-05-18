using System;
using System.Collections.Generic;

namespace WebApiPizza.Models
{
    public partial class Category
    {
        public Category()
        {
            Pizza = new HashSet<Pizza>();
        }

        public short IdCategory { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Pizza> Pizza { get; set; }
    }
}
