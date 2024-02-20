using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Order : Base
    {
        [Key]
        public Guid OrderId { get; set; }
        public String AccountId { get; set; }   
        public String RecipientName { get; set; }
        public String Address { get; set; }
        public String PhoneNo { get; set; }
        public Decimal TotalPrice { get; set; }
        public int Status { get; set; }
        public int IsPaid { get; set; }
    }
}
