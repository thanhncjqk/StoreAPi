
using BusinessLayer.CategoryBL;
using Common.DTO;
using Common.Enum;
using DataAccessLayer.BaseStoreDL;
using DataAccessLayer.BrandDL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.BaseStoreBL
{
    public class BaseStoreBL<T> : IBaseStoreBL<T>
    {
        private IBaseStoreDL<T> _baseDL;
        private IBrandDL brandDL;
        private ICategoryBL categoryDL;

        public BaseStoreBL(IBaseStoreDL<T> baseDL)
        {
            _baseDL = baseDL;
        }

        public BaseStoreBL(IBrandDL brandDL)
        {
            this.brandDL = brandDL;
        }

        public BaseStoreBL(ICategoryBL categoryDL)
        {
            this.categoryDL = categoryDL;
        }

        public int DeleteMutirecord(List<int> ids)
        {
            return _baseDL.DeleteMutiRecords(ids);
        }

        public virtual PagingData<T> GetFilterRecords(string? search, int pageSize = 10, int pageNumber = 1)
        {
            int offSet = (pageNumber - 1) * pageSize;
            return _baseDL.GetFilterRecords(search, "ModifiedDate DESC", offSet, pageSize);
        }

        public T GetRecordById(int id)
        {
            return _baseDL.GetRecordById(id);
        }

        public int InsertOneRecord(T record)
        {
            Validate(Method.Add, record);
            return _baseDL.InsertOneRecord(record);
        }

        public int UpdateOneRecord(int id, T record)
        {
            string className = typeof(T).Name;
            var primaryKeyProp = typeof(T).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(KeyAttribute), true).Count() > 0);

            if (primaryKeyProp != null)
            {
                primaryKeyProp.SetValue(record, id);
            }

            Validate(Method.Edit, record);
            return _baseDL.UpdateOneRecord(id, record);
        }
        protected virtual void Validate(Method method, T record)
        {

        }
        public static bool isEmail(string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                return false;
            }
            return Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        }

        public static string formatDatetime(DateTime date)
        {
            string day = date.Day.ToString();
            string month = date.Month.ToString();
            string year = date.Year.ToString();

            return $"{year}-{month}-{day}";
        }

        public PagingData<T> FilterRecords(string? search, int pageSize = 10, int pageNumber = 1)
        {
            throw new NotImplementedException();
        }
    }
}

