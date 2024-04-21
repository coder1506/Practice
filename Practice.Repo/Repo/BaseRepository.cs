using Microsoft.Extensions.Configuration;
using Npgsql;
using Practice.Core.Interface.Base;
using Practice.Core.Util;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Practice.Repo.Repo
{
    public class BaseRepository<T> : IBaseRepository<T>
    {
        private readonly IConfiguration _configuration;
        private IDbConnection _postgresSql;
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _postgresSql = new NpgsqlConnection(connectionString: _configuration.GetConnectionString("db_dev"));
        }
        private void AddParam(Dictionary<string, object> param, IDbCommand cmd)
        {
            foreach (var item in param)
            {
                cmd.Parameters.Add(new NpgsqlParameter(item.Key, item.Value));
            }
        }
        public int Execute(string sqlQuery, Dictionary<string, object> param)
        {
            var result = 0;
            try
            {
                _postgresSql.Open();
                using (var cmd = _postgresSql.CreateCommand())
                {
                    cmd.CommandText = sqlQuery;
                    AddParam(param, cmd);
                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                _postgresSql.Close();
                HandleUtil.HandleException(ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                _postgresSql.Close();
            }
            return result;
        }

        public List<T> Query(string sqlQuery, Dictionary<string, object> param)
        {
            var result = new List<T>();
            try
            {
                _postgresSql.Open();
                using (var cmd = _postgresSql.CreateCommand())
                {
                    cmd.CommandText = sqlQuery;
                    AddParam(param, cmd);
                    var reader = cmd.ExecuteReader();
                    DBHelper.MapReaderToData(typeof(T), result, reader);
                }
            }
            catch (Exception ex)
            {
                _postgresSql.Close();
                HandleUtil.HandleException(ex);
                throw new Exception(ex.Message);
            }
            finally
            {
                _postgresSql.Close();
            }
            return result;
        }
    }
}
