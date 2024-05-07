using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIProductData.Models
{
    public class Product
    {
        public int Id {  get; set; }

        public required string Name { get; set; }

        public decimal Price { get; set; }
    }
}
