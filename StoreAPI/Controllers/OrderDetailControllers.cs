using BusinessLayer.OrderDetailBL;
using Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailControllers : BaseStoreControllers<OrderDetail>
    {
        private IOrderDetailBL _OrderDetailBL;

        public OrderDetailControllers(IOrderDetailBL OrderDetailBL) : base(OrderDetailBL)
        {
            _OrderDetailBL = OrderDetailBL;
        }
    }
}
