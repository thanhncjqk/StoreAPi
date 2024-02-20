using BusinessLayer.ProductBL;
using Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductControllers : BaseStoreControllers<Product>
    {
        private IProductBL _ProductBL;

        public ProductControllers(IProductBL ProductBL) : base(ProductBL)
        {
            _ProductBL = ProductBL;
        }
    }
}
