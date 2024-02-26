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
        public Guid ProductId { get; set; } = Guid.NewGuid();
        public String ProductName { get; set; }

        // FE sẽ lưu ảnh ở 1 chỗ nào đó => trả vể 1 url => truyền lên để lưu vào DB
        // => 1: lưu vào thư mục public ở trên project FE
        // => 2: lưu lên S3 của AWS
        public String Images { get; set; }
        public String Description { get; set; }
        public String CategoryId { get; set; }
        public String BrandId { get; set; } 
        public int Quantity { get; set; }
        public Decimal Price { get; set; }

    }
}
