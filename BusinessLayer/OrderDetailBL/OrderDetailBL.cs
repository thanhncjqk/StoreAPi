using BusinessLayer.BaseStoreBL;
using BusinessLayer.Exceptions;
using Common.DTO;
using Common.Entities;
using Common.Enum;
using DataAccessLayer.OrderDetailDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.OrderDetailBL
{
    public class OrderDetailBL : BaseStoreBL<OrderDetail>, IOrderDetailBL
    {
        List<string> Errors = new List<string>();
        private IOrderDetailDL _orderDetailDL;
        
        public OrderDetailBL(OrderDetailDL orderDetailDL) : base(orderDetailDL)
        {
            _orderDetailDL = orderDetailDL;
        }

        protected override void Validate(Method method, OrderDetail record)
        {
            if(String.IsNullOrEmpty(record.OrderId))
            {
                Errors.Add("Missing OrderId");
            }
            if(String.IsNullOrEmpty(record.ProductId))
            {
                Errors.Add("Missing ProductId");
            }

            if(record.Quantity == null)
            {
                Errors.Add("Missing Quantity");
            }

            if(record.Price == null)
            {
                Errors.Add("Missing Price");
            }

            if(Errors.Count == 0)
            {
                throw new ValidateException(Errors);
            }
        }

        public override PagingData<OrderDetail> GetFilterRecords(string? search, int pageSize = 10, int pageNumber = 1)
        {
            if(String.IsNullOrEmpty(search))
            {
                Errors.Add("Missing OrderDetailId");
                throw new ValidateException(Errors);
            }
            string where = $"OrderID like '{search}'";
            int offSet = (pageNumber - 1) * pageSize;
            return _orderDetailDL.GetFilterRecords(where, "ModifiedDate DESC", offSet, pageSize);
        }
    }
}
