using BusinessLayer.BaseStoreBL;
using BusinessLayer.Exceptions;
using Common.DTO;
using Common.Entities;
using Common.Enum;
using DataAccessLayer.CategoryDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.CategoryBL
{
    public class CategoryBL : BaseStoreBL<Category>, ICategoryBL
    {
        List<string> Errors = new List<string>();
        private ICategoryBL _categoryDL;

        public CategoryBL(ICategoryBL categoryDL) : base(categoryDL)
        {
            _categoryDL = categoryDL;
        }

        protected override void Validate(Method method, Category record)
        {
            if (String.IsNullOrEmpty(record.CategoryName))
            {
                Errors.Add("Missing CategoryName");
            }

            if (Errors.Count > 0)
            {
                throw new ValidateException(Errors);
            }
        }
        public override PagingData<Category> GetFilterRecords(string? search, int pageSize = 10, int pageNumber = 1)
        {
            string where = $"CatergoryName like '{search}'";
            int offSet = (pageNumber - 1) * pageSize;
            return _categoryDL.GetFilterRecords(where, "ModifiedDate DESC", offSet, pageSize);

        }
    }
}

