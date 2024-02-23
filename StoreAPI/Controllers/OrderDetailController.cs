using BusinessLayer.OrderDetailBL;
using Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : BaseStoreController<OrderDetail>
    {
        private IOrderDetailBL _OrderDetailBL;

        public OrderDetailController(IOrderDetailBL OrderDetailBL) : base(OrderDetailBL)
        {
            _OrderDetailBL = OrderDetailBL;
        }
    }
}
