using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ApiModel;
using ApiRepositories;
using Dapper;

namespace ApiDataAccess
{
    public class StatusNutritionGeneralRepository:Repository<StatusNutritionGeneral>,IStatusNutritionGeneralRepository
    {
        public StatusNutritionGeneralRepository(string connectionString): base(connectionString)
        {
            
        }

        public int DeleteStatusNutritionGeneral(int id)
        {
            var parameters=new DynamicParameters();
            parameters.Add("@id",id);
            
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Execute("[DeleteStatusNutritionGeneral]",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}