using BusinessLayer.BaseStoreBL;
using BusinessLayer.Exceptions;
using Common.DTO;
using Common.Entities;
using Common.Enum;
using DataAccessLayer.ProductDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ProductBL
{
    public class ProductBL : BaseStoreBL<Product>, IProductBL
    {
        List<string> Errors = new List<string>();
        private IProductDL _productDL;

        public ProductBL (IProductDL productDL) : base(productDL)
        {
            _productDL = productDL;
        }
        protected override void Validate(Method method, Product record)
        {
            if(String.IsNullOrEmpty(record.ProductName))
            {
                Errors.Add("Missing ProductName");
            }

            if(String.IsNullOrEmpty(record.Images))
            {
                Errors.Add("Missing Images");
            }

            if(String.IsNullOrEmpty(record.Description))
            {
                Errors.Add("Missing Description");
            }

            if(String.IsNullOrEmpty(record.CategoryId))
            {
                Errors.Add("Missing CategoryID");
            }

            if(String.IsNullOrEmpty(record.BrandId))
            {
                Errors.Add("Missing BrandId");
            }

            if(record.Quantity == null)
            {
                Errors.Add("Missing Quantity");
            }

            if (record.Price == null)
            {
                Errors.Add("Missing Price");
            }

            if(Errors.Count > 0)
            {
                throw new ValidateException(Errors);
            }
        }

        public override PagingData<Product> GetFilterRecords(string? search, int pageSize = 10, int pageNumber = 1)
        {
            if (string.IsNullOrEmpty(search))
            {
                Errors.Add("Missing ProductId");
                throw new ValidateException(Errors);
            }
            string where = $"CategoryId like '{search}'";
            int offSet = (pageNumber - 1) * pageSize;
            return _productDL.GetFilterRecords(where, "ModifiedDate DESC", offSet, pageSize);
        }
    }
}
