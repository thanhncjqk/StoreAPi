using BusinessLayer.BaseStoreBL;
using BusinessLayer.Exceptions;
using Common.DTO;
using Common.Entities;
using Common.Enum;
using DataAccessLayer.BrandDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BrandBL
{
    public class BrandBL : BaseStoreBL<Brand>, IBrandBL
    {
        List<string> Errors = new List<string>();
        private IBrandDL _brandDL;

        public BrandBL(IBrandDL brandDL) : base(brandDL)
        {
            _brandDL = brandDL;
        }

        protected override void Validate(Method method, Brand record)
        {
           
           if(String.IsNullOrEmpty(record.BrandName)) 
            {
                Errors.Add("Missing BrandName");
            }

           if(Errors.Count > 0)
            {
                throw new ValidateException(Errors);
            }
        }

        public override PagingData<Brand> GetFilterRecords(string? search, int pageSize = 10, int pageNumber = 1)
        {
            string where = $"TrainCarId like '{search}'";
            int offSet = (pageNumber - 1) * pageSize;
            return _brandDL.GetFilterRecords(where, "ModifiedDate DESC", offSet, pageSize);
        }
    }
}
