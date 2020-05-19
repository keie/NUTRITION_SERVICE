using System.Data.SqlClient;
using ApiModel;
using ApiRepositories;
using Dapper;

namespace ApiDataAccess
{
    public class GradeRepository:Repository<Grade>,IGradeRepository
    {
        public GradeRepository(string connectionString): base(connectionString)
        {
            
        }

        public int DeleteGrade(int id)
        {
            var parameters=new DynamicParameters();
            parameters.Add("@id",id);
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Execute("[DeleteGrade]",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}