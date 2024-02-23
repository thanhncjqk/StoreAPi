using Common.DTO;
using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BaseStoreDL
{
    public class BaseStoreDL<T> : IBaseStoreDL<T>
    {
        public int DeleteMutiRecords(List<int> ids)
        {
            string className = typeof(T).Name;
            string stored = $"Proc_{className}_DeleteMultiple";

            var parameter = new DynamicParameters();

            string whereClause = $"'{string.Join("', '", ids)}'";

            parameter.Add("$IDs", whereClause);

            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                int a = mySqlConnection.Execute(stored, parameter, commandType: System.Data.CommandType.StoredProcedure);

                return a;
            }
        }

        public PagingData<T> GetFilterRecords(string? search, string? sort, int offSet = 0, int limit = 10)
        {
            string className = typeof(T).Name;
            string storedProc = $"Proc_{className}_FilterRecords";

            var parameters = new DynamicParameters();

            parameters.Add("$Skip", offSet);
            parameters.Add("$Take", limit);
            parameters.Add("$Sort", sort);
            parameters.Add("$Where", search);

            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                var records = mySqlConnection.QueryMultiple(storedProc, parameters, commandType: System.Data.CommandType.StoredProcedure);

                return new PagingData<T>()
                {
                    Data = records.Read<T>().ToList(),
                    TotalCount = records.Read<long>().Single()
                };
            }

        }

        public virtual T GetRecordById(int id)
        {
            string className = typeof(T).Name;
            string stored = $"Proc_{className}_GetByID";

            var parameters = new DynamicParameters();

            var primaryKeyProp = typeof(T).GetProperties().FirstOrDefault(prop => prop.GetCustomAttributes(typeof(KeyAttribute), true).Count() > 0);
            parameters.Add($"@${primaryKeyProp?.Name}", id);


            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                var record = mySqlConnection.QueryFirstOrDefault<T>(stored, parameters, commandType: System.Data.CommandType.StoredProcedure);

                return record;
            }
        }

        public int InsertOneRecord(T record)
        {
            string className = typeof(T).Name;
            string storedProc = $"Proc_{className}_InsertOne";

            var parameters = new DynamicParameters();
            var props = typeof(T).GetProperties();
            foreach (var prop in props)
            {
                var propName = $"${prop.Name}";
                var propValue = prop.GetValue(record) ;
                parameters.Add(propName, propValue);
            }
            
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                int affectedRow = mySqlConnection.Execute(storedProc, parameters, commandType: System.Data.CommandType.StoredProcedure);


                return affectedRow;
            }
        }

        public DynamicParameters SetDynamicParameters(T record)
        {
            var parameters = new DynamicParameters();

            var props = typeof(T).GetProperties();

            foreach (var prop in props)
            {
                string propName = $"@${prop.Name}";
                var propValue = prop.GetValue(record);
                parameters.Add(propName, propValue);
            }
            return parameters;
        }

        public int UpdateOneRecord(int id, T record)
        {
            string className = typeof(T).Name;
            string storedProc = $"Proc_{className}_UpdateOne";

            var parameters = SetDynamicParameters(record);
            
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                int affectedRow = mySqlConnection.Execute(storedProc, parameters, commandType: System.Data.CommandType.StoredProcedure);

                var result = 0;
                if (affectedRow > 0)
                {
                    result = (int)id;
                }
                return result;
            }
        }
    }
}

