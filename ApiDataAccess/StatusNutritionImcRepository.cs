using System.Data.SqlClient;
using ApiModel;
using ApiRepositories;
using Dapper;

namespace ApiDataAccess
{
    public class StatusNutritionImcRepository:Repository<StatusNutritionImc>,IStatusNutritionImcRepository
    {
        public StatusNutritionImcRepository(string connectionString):base(connectionString)
        {
            
        }
        public int DeleteImc(int id)
        {
            var parameters=new DynamicParameters();
            parameters.Add("@id",id);
            
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Execute("[DeleteImc]",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}