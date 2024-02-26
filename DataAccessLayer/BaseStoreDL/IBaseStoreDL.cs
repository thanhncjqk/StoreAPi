using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BaseStoreDL
{
    public interface IBaseStoreDL<T>
    {
        public PagingData<T> GetFilterRecords(string? search, string? sort, int offSet = 0, int limit = 10);

        public T GetRecordById(Guid id);

        public int InsertOneRecord(T record);

        public Guid UpdateOneRecord(Guid id, T record);

        public int DeleteMutiRecords(List<Guid> ids);

    }
}