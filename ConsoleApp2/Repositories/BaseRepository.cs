using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ConsoleApp2.Repositories
{
    internal abstract class BaseRepository<T>
    {
        string connectionString = "Server=DESKTOP-ODVSB0U;DataBase=DataSchoolDb;Trusted_Connection=True;";
        public IEnumerable<T> GetAll()
        {
            var Query = $"SELECT * FROM {typeof(T).Name}";
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                return conn.Query<T>(Query);
            }
        }



        public void Add<T>(T Data)
        {
            var column = GetColumns();
            var stringOfColumn = string.Join(", ", column);
            var stringOfValue = string.Join(", ", column.Select(w => "@" + w));
            var query = $"INSERT INTO {typeof(T).Name} ({stringOfColumn}) VALUES ({stringOfValue})";
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                conn.Execute(query, (object)Data);
            }
        }
        public virtual void Delete(T Entity)
        {
            var columns = GetColumns();

            var query = $"DELETE FROM {typeof(T).Name} WHERE Id = @Id";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Execute(query, Entity);
            }
        }

        public void Update(T Data)
        {
            var columns = GetColumns();

            var stringOfColumns = string.Join(", ", columns.Select(e => $"{e} = @{e}"));
            var query = $"UPDATE {typeof(T).Name} SET {stringOfColumns} WHERE Id = @Id";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Execute(query, Data);
            }
        }

        private IEnumerable<string> GetColumns()
        {
            return typeof(T)
                .GetProperties()
                .Where(w => w.Name != "Id" && !w.PropertyType.GetTypeInfo().IsGenericType)
                .Select(w => w.Name);
        }
    }


}
