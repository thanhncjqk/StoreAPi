using BusinessLayer.CategoryBL;
using Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseStoreController<Category>
    {
        private ICategoryBL _categoryBL;

        public CategoryController(ICategoryBL categoryBL) : base (categoryBL)
        {
            _categoryBL = categoryBL;
        }
    }
}
