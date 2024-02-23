using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Base
    {

        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;
        public DateTime? DeleteDate { get; set; }

    }
}

