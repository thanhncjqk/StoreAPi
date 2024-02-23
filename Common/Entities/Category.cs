using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Category : Base
    {
        [Key]
        public Guid CategoryId { get; set; } = Guid.NewGuid();
        public String CategoryName { get; set; }
    }
}
