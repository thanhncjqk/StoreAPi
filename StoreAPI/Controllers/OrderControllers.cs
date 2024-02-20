using BusinessLayer.OrderBL;
using Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderControllers : BaseStoreControllers<Order>
    {
        private IOrderBL _OrderBL;

        public OrderControllers(IOrderBL OrderBL) : base(OrderBL)
        {
            _OrderBL = OrderBL;
        }
    }
}
