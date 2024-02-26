using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Account : Base
    {
        [Key]
        public Guid AccountId { get; set; } = Guid.NewGuid();
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Avata { get; set; }
        public int DoB { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }

    }
}
