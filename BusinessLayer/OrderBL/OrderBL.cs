using BusinessLayer.BaseStoreBL;
using BusinessLayer.Exceptions;
using Common.DTO;
using Common.Entities;
using Common.Enum;
using DataAccessLayer.OrderDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.OrderBL
{
    public class OrderBL : BaseStoreBL<Order>, IOrderBL
    {
        List<string> Errors = new List<string>();
        private IOrderDL _orderDL;

        public OrderBL(IOrderDL orderDL) : base(orderDL)
        {
            _orderDL = orderDL;
        }

        protected override void Validate(Method method, Order record)
        {
            if(String.IsNullOrEmpty(record.AccountId))
            {
                Errors.Add("Missing AccountId");
            }

            if(String.IsNullOrEmpty(record.RecipientName))
            {
                Errors.Add("Missing RecepientName");
            }
            
            if(String.IsNullOrEmpty(record.Address))
            {
                Errors.Add("Missing Address");
            }

            if(String.IsNullOrEmpty(record.PhoneNo))
            {
                Errors.Add("Missing PhoneNo");
            }
            
            if(record.TotalPrice == null)
            {
                Errors.Add("Missing TotalPrice");
            }

            if(record.Status == null)
            {
                Errors.Add("Missing Status");
            }

            if(record.IsPaid == null)
            {
                Errors.Add("Missing Ispaid");
            }

            if(Errors.Count > 0)
            {
                throw new ValidateException(Errors);
            }
        }

        public override PagingData<Order> GetFilterRecords(string? search, int pageSize = 10, int pageNumber = 1)
        {
            if (String.IsNullOrEmpty(search))
            {
                Errors.Add("Missing OrderId");
                throw new ValidateException(Errors);
            }

            string where = $"AccountId like '{search}'";
            int offSet = (pageNumber - 1) * pageSize;
            return _orderDL.GetFilterRecords(where, "ModifiedDate DESC", offSet, pageSize);
        }
    }
}
