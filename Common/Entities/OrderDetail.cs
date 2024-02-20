using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class OrderDetail : Base
    {
        [Key]
        public Guid OrderDetailId { get; set; }
        public String OrderId { get; set; }
        public String ProductId { get; set; }
        public int Quantity { get; set; }
        public Decimal Price {get; set; }
    }
}
