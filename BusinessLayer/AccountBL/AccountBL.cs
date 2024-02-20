using BusinessLayer.BaseStoreBL;
using BusinessLayer.Exceptions;
using Common.DTO;
using Common.Entities;
using Common.Enum;
using DataAccessLayer.AccountDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.AccountBL
{
    public class AccountBL : BaseStoreBL<Account>, IAccountBL
    {
        List<string> Errors = new List<string>();
        private IAccountDL _accountDL;

        public AccountBL(IAccountDL accountDL) : base(accountDL)
        {
            _accountDL = accountDL;
        }

        protected override void Validate(Method method, Account record)
        {
            if(String.IsNullOrEmpty(record.FullName))
            {
                Errors.Add("Missing FullName");
            }

            if (String.IsNullOrEmpty(record.Address))
            {
                Errors.Add("Mising Address");
            }

            if (String.IsNullOrEmpty(record.PhoneNo))
            {
                Errors.Add("Missing PhoneNo");
            }

            if (String.IsNullOrEmpty(record.Email))
            {
                Errors.Add("Missing Email");
            }

            if (String.IsNullOrEmpty(record.Avata))
            {
                Errors.Add("Missing Avata");
            }

            if (record.DoB == null)
            {
                Errors.Add("Missing FullName");
            }

            if (String.IsNullOrEmpty(record.Password))
            {
                Errors.Add("Missing Password");
            }

            if (record.Role == null)
            {
                Errors.Add("Missing FullName");
            }

            if (Errors.Count > 0)
            {
                throw new ValidateException(Errors);
            }
        }

        public override PagingData<Account> GetFilterRecords(string? search, int pageSize = 10, int pageNumber = 1)
        {
            if (string.IsNullOrEmpty(search))
            {
                Errors.Add("Missing AccountId ");
                throw new ValidateException(Errors);
            }
            string where = $"AccountId like '{search}'";
            int offSet = (pageNumber - 1) * pageSize;
            return _accountDL.GetFilterRecords(where, "ModifiedDate DESC", offSet, pageSize);
        }
    }
 }
    

