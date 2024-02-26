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
        public PagingData<T> FilterRecords(string? search, int pageSize = 10, int pageNumber = 1);

        public T GetRecordById(Guid id);

        public int InsertOneRecord(T record);

        public Guid UpdateOneRecord(Guid id, T record);

        public int DeleteMutirecord(List<Guid> ids);
    }
}

