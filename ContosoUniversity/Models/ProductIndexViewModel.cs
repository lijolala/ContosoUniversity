using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
    public class ProductIndexViewModel
    {
        public bool IncludeDiscontinued { get; set; }
        public List<Product> Products { get; set; }
    }
}
