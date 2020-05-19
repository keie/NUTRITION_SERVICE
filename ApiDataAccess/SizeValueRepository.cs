using System.Data.SqlClient;
using ApiModel;
using ApiRepositories;
using Dapper;

namespace ApiDataAccess
{
    public class SizeValueRepository:Repository<SizeValue>,ISizeValueRepository
    {
        public SizeValueRepository(string connectionString):base(connectionString)
        {
            
        }

        public int DeleteSizeValue(int id)
        {
            var parameters= new DynamicParameters();
            parameters.Add("@id",id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Execute("[DeleteSizeValue]",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}