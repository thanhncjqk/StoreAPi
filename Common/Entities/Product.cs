using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Product : Base
    {
        [Key] 
        public Guid ProductId { get; set; }
        public String ProductName { get; set; }
        public String Images { get; set; }
        public String Description { get; set; }
        public String CategoryId { get; set; }
        public String BrandId { get; set; } 
        public int Quantity { get; set; }
        public Decimal Price { get; set; }

    }
}
