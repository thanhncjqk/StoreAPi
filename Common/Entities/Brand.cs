using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Brand : Base
    {
        [Key]
        public Guid BrandId { get; set; } = Guid.NewGuid();
        public String BrandName { get; set; }

    }
}
