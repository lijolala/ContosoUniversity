using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
    public class Product
    {
        public string Description { get; set; }
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public bool IsDiscontinued { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
    }
}
