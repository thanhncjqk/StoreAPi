using BusinessLayer.ProductBL;
using Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseStoreController<Product>
    {
        private IProductBL _ProductBL;

        public ProductController(IProductBL ProductBL) : base(ProductBL)
        {
            _ProductBL = ProductBL;
        }
    }
}
