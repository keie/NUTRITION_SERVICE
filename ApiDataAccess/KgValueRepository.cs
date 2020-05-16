using System.Buffers.Text;
using System.Data;
using System.Data.SqlClient;
using ApiModel;
using ApiRepositories;
using Dapper;

namespace ApiDataAccess
{
    public class KgValueRepository: Repository<KgValue>,IKgValueRepostitory
    {

        public KgValueRepository(string connectionString): base(connectionString)
        {
            
        }

        public int DeleteKgValue(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Execute("[DeleteKgValue]",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}