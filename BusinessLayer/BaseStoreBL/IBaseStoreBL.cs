using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BaseStoreBL
{
    public interface IBaseStoreBL<T>
    {
        public PagingData<T> GetFilterRecords(string? search, string v, int pageSize = 10, int pageNumber = 1);

        public T GetRecordById(int id);

        public int DeleteOneRecord(int id);

        public int InsertOneRecord(T record);

        public int UpdateOneRecord(int id, T record);

        public int DeleteMutirecord(List<int> ids);
        PagingData<T> GetFilterRecords(string? search, int pageSize, int pageNumber);
    }
}

