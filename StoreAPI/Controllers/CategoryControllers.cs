using BusinessLayer.CategoryBL;
using Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryControllers : BaseStoreControllers<Category>
    {
        private ICategoryBL _CategoryBL;

        public CategoryControllers(ICategoryBL CategoryBL) : base (CategoryBL)
        {
            _CategoryBL = CategoryBL;
        }
    }
}
