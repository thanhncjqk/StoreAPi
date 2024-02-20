using BusinessLayer.BrandBL;
using Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Brand_DetailController : BaseStoreControllers<Brand>
    {
        private IBrandBL _BrandBL;

        public Brand_DetailController(IBrandBL BrandBL) : base (BrandBL)
        {
            _BrandBL = BrandBL;
        }
    }
}
