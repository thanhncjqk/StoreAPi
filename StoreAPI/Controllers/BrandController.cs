using BusinessLayer.BrandBL;
using Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : BaseStoreController<Brand>
    {
        private IBrandBL _brandBL;

        public BrandController(IBrandBL brandBL) : base (brandBL)
        {
            _brandBL = brandBL;
        }
    }
}
