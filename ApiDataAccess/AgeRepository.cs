using System.Data.SqlClient;
using ApiModel;
using ApiRepositories;
using Dapper;

namespace ApiDataAccess
{
    public class AgeRepository:Repository<AgeValue>,IAgeRepository
    {
        public AgeRepository(string connectionString):base(connectionString)
        {
            
        }

        public int DeleteAgeValue(int id)
        {
            var parameters=new DynamicParameters();
            parameters.Add("@id",id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Execute("[AgeValueDelete]",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}